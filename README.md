# stockresearchrecord
#### Author: James Yoo
### Description
An API to have a list of stocks with infromation to look up the due dilligence behind the stock. I haven't figured out the event portion of the api, but I would hope to fix it in the near future. 

##Changes 
I decided to change my idea because I could not figure out the chain of errors.

##API Endpoints
| HTTP Method |  API Endpoint                         | Description                                                                 |
| ----------- | ------------------------------------- | --------------------------------------------------------------------------- |                               
| GET         | /api/Stock                            | Return a list of all stocks with the research and headlines                 |
| GET         | /api/Stock/{StockId}                  | Return a stock for a given id                                               |
| GET         | /api/Stock/{StockId}/research         | Return the research from a stock for a given id                             |
| GET         | /api/Stock/{StockId}/companyevent     | Return an event from a stock for a given id                                 |
| POST        | /api/Stock                            | Add a new Stock                                                             |
| DELETE      | /api/Stock/{StockId}                  | Delete an existing stock for a given id in all tables                       |
