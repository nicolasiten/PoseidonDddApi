
CREATE TABLE BidList (
  BidListId INT NOT NULL IDENTITY PRIMARY KEY,
  Account NVARCHAR(30) NOT NULL,
  Type NVARCHAR(30) NOT NULL,
  BidQuantity FLOAT,
  AskQuantity FLOAT,
  Bid FLOAT ,
  Ask FLOAT,
  Benchmark NVARCHAR(125),
  BidListDate DATETIME,
  Commentary NVARCHAR(125),
  Security NVARCHAR(125),
  Status NVARCHAR(10),
  Trader NVARCHAR(125),
  Book NVARCHAR(125),
  CreationName NVARCHAR(125),
  CreationDate DATETIME ,
  RevisionName NVARCHAR(125),
  RevisionDate DATETIME ,
  DealName NVARCHAR(125),
  DealType NVARCHAR(125),
  SourceListId NVARCHAR(125),
  Side NVARCHAR(125)
)

CREATE TABLE Trade (
  TradeId INT NOT NULL IDENTITY PRIMARY KEY,
  Account NVARCHAR(30) NOT NULL,
  Type NVARCHAR(30) NOT NULL,
  BuyQuantity FLOAT,
  SellQuantity FLOAT,
  BuyPrice FLOAT,
  SellPrice FLOAT,
  TradeDate DATETIME,
  Security NVARCHAR(125),
  Status NVARCHAR(10),
  Trader NVARCHAR(125),
  Benchmark NVARCHAR(125),
  Book NVARCHAR(125),
  CreationName NVARCHAR(125),
  CreationDate DATETIME ,
  RevisionName NVARCHAR(125),
  RevisionDate DATETIME,
  DealName NVARCHAR(125),
  DealType NVARCHAR(125),
  SourceListId NVARCHAR(125),
  Side NVARCHAR(125)
)

CREATE TABLE CurvePoint (
  Id INT NOT NULL IDENTITY PRIMARY KEY,
  CurveId tinyint,
  AsOfDate DATETIME,
  Term FLOAT,
  Value FLOAT,
  CreationDate DATETIME
)

CREATE TABLE Rating (
  Id INT NOT NULL IDENTITY PRIMARY KEY,
  MoodysRating NVARCHAR(125),
  SandPRating NVARCHAR(125),
  FitchRating NVARCHAR(125),
  OrderNumber tinyint
)

CREATE TABLE RuleName (
  Id INT NOT NULL IDENTITY PRIMARY KEY,
  Name NVARCHAR(125),
  Description NVARCHAR(125),
  Json NVARCHAR(125),
  Template NVARCHAR(512),
  SqlStr NVARCHAR(125),
  SqlPart NVARCHAR(125)
)
