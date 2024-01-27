CREATE DOMAIN GenderType AS VARCHAR(1)
CHECK (VALUE IN ('M','F'));

CREATE DOMAIN proper_email AS VARCHAR(60)
CHECK (VALUE ~* '[A-Za-z0-9._%-]+@[A-Za-z0-9.-]+[.][A-Za-z]+$');

CREATE DOMAIN Phone_number AS VARCHAR(11)
CHECK (VALUE ~ '^05[0-9]{9}$');

CREATE DOMAIN Bus_plaque AS VARCHAR (10)
CHECK (VALUE ~ '^[0-9]{2} [A-Z]{3} [0-9]{3}$');

CREATE DOMAIN Passwords AS VARCHAR(20)
CHECK (LENGTH(VALUE) >= 8 AND VALUE ~ '[A-Z]' AND VALUE ~ '[a-z]' AND VALUE ~ '[0-9]'AND 
        VALUE ~ '[!@#$%^&*(),.?":{}|<>]');
		
CREATE DOMAIN Card_Number AS VARCHAR(16)
CHECK (VALUE  ~ '^[0-9]+$');