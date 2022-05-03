CREATE DATABASE stockInfoDB;
USE stockInfoDB;

CREATE TABLE Stock(	
	StockID INT NOT NULL AUTO_INCREMENT,
	StockTicker VARCHAR(100) NOT NULL,
    StockName VARCHAR(100) NOT NULL,
    PRIMARY KEY (StockID)
);

CREATE TABLE Research(
	StockID INT NOT NULL AUTO_INCREMENT,
	StockTicker VARCHAR(100) NOT NULL,
    StockName VARCHAR(100) NOT NULL,
    Sector VARCHAR(100) NOT NULL,
    Dilligence VARCHAR(10000) NOT NULL,
	PRIMARY KEY (StockID) 
);

CREATE TABLE CompanyEvent(
	StockID INT NOT NULL AUTO_INCREMENT,
	StockTicker VARCHAR(100) NOT NULL,
	StockName VARCHAR(100) NOT NULL,
    Headline VARCHAR(100) NOT NULL,
    HeadlineDate VARCHAR(100) NOT NULL,
    Impact VARCHAR(10000) NOT NULL,
	PRIMARY KEY (StockID) 
);



ALTER TABLE Stock ADD CONSTRAINT TickerLength CHECK ((LENGTH(StockTicker)) <= 5); 
ALTER TABLE CompanyEvent ADD CONSTRAINT TickerLengthEvent CHECK ((LENGTH(StockTicker)) <= 5); 
ALTER TABLE Research ADD CONSTRAINT TickerLengthResearch CHECK ((LENGTH(StockTicker)) <= 5); 

ALTER TABLE Research ADD CONSTRAINT fk_research FOREIGN KEY (StockID) REFERENCES Stock(StockID);
ALTER TABLE CompanyEvent ADD CONSTRAINT fk_event FOREIGN KEY (StockID) REFERENCES Stock(StockID);

INSERT INTO Research(stockTicker, stockName, Sector, Dilligence) VALUES ("INTC","Intel Corporation","Tech","Greatly undervalue compared to current stock price, heavy investment into research");
INSERT INTO CompanyEvent (stockTicker, stockName, Headline, HeadlineDate, Impact) VALUES ("INTC","Intel Corporation","Nvidia Would Consider Using Intel as a Foundry", "3/29/2022", "Bullish");
INSERT INTO Stock (stockTicker, stockName) VALUES ("INTC", "Intel Corporation");

SELECT * FROM Research;
SELECT * FROM CompanyEvent;
SELECT * FROM Stock;
