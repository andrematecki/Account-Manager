using Microsoft.AspNetCore.Mvc;
using AccountManager._1._Presentation.RequestModel;
using AccountManager._3._Domain.Entities;
using AccountManager._3._Domain.Services;
using AccountManager._1._Presentation.ResponseModel;
using System;
using AccountManager._3._Domain.Exceptions;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Net;

namespace AccountManager._1._Presentation.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : ControllerApiBase
    {

        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        /// <summary>
        /// Create a new account
        /// </summary>
        /// <remarks>
        /// If owner does not exist will be created a new one
        /// </remarks>
        /// <param name="account">Account payload</param>
        /// <returns></returns>
        /// <response code="200">Account created</response>
        /// <response code="400">Account properties are not setted corretly</response>
        [HttpPost]
        [ProducesResponseType(typeof(AccountCreationResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(MessageResponse), (int)HttpStatusCode.BadRequest)]
        public IActionResult CreateAccount([FromBody] AccountCreationRequest account)
        {
            try
            {
                if (! ModelState.IsValid)
                    return BadRequest(ModelState);

                Account domainModel = account.ToDomain();
                domainModel = _accountService.Add(domainModel);
                return Ok(new AccountCreationResponse(domainModel));
            }
            catch(InvalidParametersException)
            {
                return BadRequest("Account properties are not setted corretly.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Withdraws from the account
        /// </summary>
        /// <param name="withdraw">Operations payload</param>
        /// <returns></returns>
        /// <response code="200">Withdraw done</response>
        /// <response code="400">
        /// Account Number and transaction value must be positive <br />
        /// Account Number not found <br />
        /// Account is blocked <br />
        /// Account withdraw limit exceeded <br />
        /// Account does not have balance enough <br />
        /// </response>
        [Route("withdraw")]
        [HttpPost]
        [ProducesResponseType(typeof(AccountOperationsResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(MessageResponse), (int)HttpStatusCode.BadRequest)]
        public IActionResult Withdraw([FromBody] TransactionOperationsRequest withdraw)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                Account account = _accountService.Withdraw(withdraw.AccountNumber, withdraw.Value);
                return Ok(new AccountOperationsResponse(account));
            }
            catch (ParametersLessThanZeroException)
            {
                return BadRequest("Account Number and transaction value must be positive.");
            }
            catch (AccountNotFoundException)
            {
                return BadRequest("Account Number not found.");
            }
            catch (AccountBlockedException)
            {
                return BadRequest("Account is blocked.");
            }
            catch (WithdrawLimitExceededException)
            {
                return BadRequest("Account withdraw limit exceeded.");
            }
            catch (BalanceInsufficientException)
            {
                return BadRequest("Account does not have balance enough.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deposits to the account
        /// </summary>
        /// <param name="withdraw">Operations payload</param>
        /// <returns></returns>
        /// <response code="200">Deposit done</response>
        /// <response code="400">
        /// Account Number and transaction value must be positive <br />
        /// Account Number not found <br />
        /// Account is blocked <br />
        /// </response>
        [ProducesResponseType(typeof(AccountOperationsResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(MessageResponse), (int)HttpStatusCode.BadRequest)]
        [Route("deposit")]
        [HttpPost]
        public IActionResult Deposit([FromBody] TransactionOperationsRequest withdraw)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                Account account = _accountService.Deposit(withdraw.AccountNumber, withdraw.Value);
                return Ok(new AccountOperationsResponse(account));
            }
            catch (ParametersLessThanZeroException)
            {
                return BadRequest("Account Number and transaction value must be positive.");
            }
            catch (AccountNotFoundException)
            {
                return BadRequest("Account Number not found.");
            }
            catch (AccountBlockedException)
            {
                return BadRequest("Account is blocked.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Account balance
        /// </summary>
        /// <param name="accountNumber">Account number</param>
        /// <returns></returns>
        /// <response code="200">Balance consulted</response>
        /// <response code="400">Account is blocked</response>
        [ProducesResponseType(typeof(AccountOperationsResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(MessageResponse), (int)HttpStatusCode.BadRequest)]
        [Route("balance/{accountNumber}")]
        [HttpGet]
        public IActionResult Balace([FromRoute] int accountNumber)
        {
            try
            {
                var account = _accountService.GetById(accountNumber);
                return Ok(new AccountOperationsResponse(account));
            }
            catch (AccountBlockedException)
            {
                return BadRequest("Account is blocked.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Block the account
        /// </summary>
        /// <param name="accountNumber">Account number</param>
        /// <returns></returns>
        /// <response code="200">
        /// Account has been blocked <br/>
        /// Account is already blocked
        /// </response>
        /// <response code="400">Account Number not found</response>
        [ProducesResponseType(typeof(MessageResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(MessageResponse), (int)HttpStatusCode.BadRequest)]
        [Route("blockAccount/{accountNumber}")]
        [HttpPatch]
        public IActionResult BlockAccount([FromRoute] int accountNumber)
        {
            try
            {
                var account = _accountService.BlockAccount(accountNumber);
                return Ok("Account has been blocked.");
            }
            catch (AccountNotFoundException)
            {
                return BadRequest("Account Number not found.");
            }
            catch (AccountBlockedException)
            {
                return Ok("Account is already blocked.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Consult account statement
        /// </summary>
        /// <param name="statementRequest">Statement filters</param>
        /// <returns></returns>
        /// <response code="200">Statement consulted</response>
        /// <response code="400">
        /// Account Number not found <br />
        /// Account is blocked
        /// </response>
        [ProducesResponseType(typeof(StatementResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(MessageResponse), (int)HttpStatusCode.BadRequest)]
        [Route("statement")]
        [HttpPost]
        public IActionResult Statement([FromBody] StatementRequest statementRequest)
        {
            try
            {
                var transactions = _accountService.Statement(statementRequest.AccountNumber, statementRequest.InitialDate, statementRequest.EndDate);
                return Ok(new StatementResponse(statementRequest.AccountNumber, transactions));
            }
            catch (AccountNotFoundException)
            {
                return BadRequest("Account Number not found.");
            }
            catch (AccountBlockedException)
            {
                return Ok("Account is blocked.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}