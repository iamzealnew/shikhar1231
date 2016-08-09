/******Write a query update the FromLocation,ToLocation,Fare for a FlightID.******/

update tbl_Flight1213929 set FromLocation='1' , ToLocation='2' , Fare = '8500' where FlightID = '1';

select * from tbl_Flight1213929;

/****** Display all Special Flight Details ******/ 

select * from tbl_Flight1213929 where IsSpecialFlight = '1';

/****** Display the details like FlightID, FlightName, FromLocation,ToLocation,Fare. ******/

select FlightID, FlightName, FromLocation, ToLocation, Fare from tbl_Flight1213929;

/****** Write insert stored procedure for Flight details. ******/

CREATE PROCEDURE [dbo].[insertFlight1213929]
	@flightName varchar (20),
	@fromLocation int,
	@toLocation int,
	@isSpecalFlight int, 
	@fare int
AS
insert into tbl_Flight1213929( FlightName, FromLocation, ToLocation, IsSpecialFlight, Fare) values (@flightName, @fromLocation, @toLocation, @isSpecalFlight, @fare)
RETURN 0

