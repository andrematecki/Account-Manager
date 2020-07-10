CREATE TABLE "People" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_People" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NULL,
    "CPF" TEXT NULL,
    "BirthdayDate" TEXT NOT NULL
);

CREATE TABLE "Accounts" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Accounts" PRIMARY KEY AUTOINCREMENT,
    "PersonId" INTEGER NULL,
    "WithdrawLimit" TEXT NOT NULL,
    "Active" INTEGER NOT NULL,
    "Type" INTEGER NOT NULL,
    "CreationDate" TEXT NOT NULL,
    CONSTRAINT "FK_Accounts_People_PersonId" FOREIGN KEY ("PersonId") REFERENCES "People" ("Id") ON DELETE RESTRICT
);

CREATE TABLE "Transactions" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Transactions" PRIMARY KEY AUTOINCREMENT,
    "Value" TEXT NOT NULL,
    "TransactionDate" TEXT NOT NULL,
    "AccountId" INTEGER NULL,
    CONSTRAINT "FK_Transactions_Accounts_AccountId" FOREIGN KEY ("AccountId") REFERENCES "Accounts" ("Id") ON DELETE RESTRICT
);

CREATE INDEX "IX_Accounts_PersonId" ON "Accounts" ("PersonId");

CREATE INDEX "IX_Transactions_AccountId" ON "Transactions" ("AccountId");