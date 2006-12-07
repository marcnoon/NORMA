﻿START TRANSACTION ISOLATION LEVEL SERIALIZABLE, READ WRITE;

CREATE SCHEMA PersonCountryDemo;

CREATE DOMAIN PersonCountryDemo.Title AS CHARACTER VARYING(4) CONSTRAINT Title_Chk CHECK (VALUE IN ('Dr', 'Prof', 'Mr', 'Mrs', 'Miss', 'Ms')) ;

CREATE DOMAIN PersonCountryDemo.Region_code AS CHARACTER(8) CONSTRAINT Region_code_Chk CHECK ((CHARACTER_LENGTH(TRIM(BOTH FROM VALUE))) >= 8) ;

CREATE TABLE PersonCountryDemo.Person
(
	Person_id BIGSERIAL NOT NULL, 
	LastName CHARACTER VARYING(30) NOT NULL, 
	FirstName CHARACTER VARYING(30) NOT NULL, 
	Title PersonCountryDemo.Title , 
	Country_Country_name CHARACTER VARYING(20) , 
	CONSTRAINT InternalUniquenessConstraint1 PRIMARY KEY(Person_id)
);

CREATE TABLE PersonCountryDemo.Country
(
	Country_name CHARACTER VARYING(20) NOT NULL, 
	Region_Region_code PersonCountryDemo.Region_code , 
	CONSTRAINT InternalUniquenessConstraint3 PRIMARY KEY(Country_name)
);

ALTER TABLE PersonCountryDemo.Person ADD CONSTRAINT Country_FK FOREIGN KEY (Country_Country_name)  REFERENCES PersonCountryDemo.Country (Country_name)  ON DELETE RESTRICT ON UPDATE RESTRICT;


CREATE FUNCTION PersonCountryDemo.InsertPerson
(
	Person_id BIGINT , 
	LastName CHARACTER VARYING(30) , 
	FirstName CHARACTER VARYING(30) , 
	Title CHARACTER VARYING(4) , 
	Country_Country_name CHARACTER VARYING(20) 
)
RETURNS VOID
LANGUAGE SQL
AS
	'INSERT INTO PersonCountryDemo.Person(Person_id, LastName, FirstName, Title, Country_Country_name)
	VALUES ($1, $2, $3, $4, $5)';

CREATE FUNCTION PersonCountryDemo.DeletePerson
(
	Person_id BIGINT 
)
RETURNS VOID
LANGUAGE SQL
AS
	'DELETE FROM PersonCountryDemo.Person
	WHERE Person_id = $1';

CREATE FUNCTION PersonCountryDemo.UpdatePersonLastName
(
	LastName CHARACTER VARYING(30) 
)
RETURNS VOID
LANGUAGE SQL
AS
	'UPDATE PersonCountryDemo.Person
SET LastName = LastName
	WHERE Person_id = $';

CREATE FUNCTION PersonCountryDemo.UpdatePersonFirstName
(
	FirstName CHARACTER VARYING(30) 
)
RETURNS VOID
LANGUAGE SQL
AS
	'UPDATE PersonCountryDemo.Person
SET FirstName = FirstName
	WHERE Person_id = $';

CREATE FUNCTION PersonCountryDemo.UpdatePersonTitle
(
	Title CHARACTER VARYING(4) 
)
RETURNS VOID
LANGUAGE SQL
AS
	'UPDATE PersonCountryDemo.Person
SET Title = Title
	WHERE Person_id = $';

CREATE FUNCTION PersonCountryDemo.UpdtPrsnCntry_Cntry_nm
(
	Country_Country_name CHARACTER VARYING(20) 
)
RETURNS VOID
LANGUAGE SQL
AS
	'UPDATE PersonCountryDemo.Person
SET Country_Country_name = Country_Country_name
	WHERE Person_id = $';

CREATE FUNCTION PersonCountryDemo.InsertCountry
(
	Country_name CHARACTER VARYING(20) , 
	Region_Region_code CHARACTER(8) 
)
RETURNS VOID
LANGUAGE SQL
AS
	'INSERT INTO PersonCountryDemo.Country(Country_name, Region_Region_code)
	VALUES ($1, $2)';

CREATE FUNCTION PersonCountryDemo.DeleteCountry
(
	Country_name CHARACTER VARYING(20) 
)
RETURNS VOID
LANGUAGE SQL
AS
	'DELETE FROM PersonCountryDemo.Country
	WHERE Country_name = $1';

CREATE FUNCTION PersonCountryDemo.UpdateCountryCountry_name
(
	Country_name CHARACTER VARYING(20) 
)
RETURNS VOID
LANGUAGE SQL
AS
	'UPDATE PersonCountryDemo.Country
SET Country_name = Country_name
	WHERE Country_name = $1';

CREATE FUNCTION PersonCountryDemo.UpdtCntryRgn_Rgn_cd
(
	Region_Region_code CHARACTER(8) 
)
RETURNS VOID
LANGUAGE SQL
AS
	'UPDATE PersonCountryDemo.Country
SET Region_Region_code = Region_Region_code
	WHERE Country_name = $';
COMMIT WORK;

