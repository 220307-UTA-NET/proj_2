-- might want to add ipaddress to this table later, users could exploit by using the guest table by logging out
-- and logging into user to change a pixel again

CREATE TABLE User (
  id INT IDENTITY(1,1) PRIMARY KEY,
  username varchar(255) NOT NULL,
  password varchar(255) NOT NULL,
  lastPlace DateTime,
  created_at DATETIME DEFAULT SYSDATETIME(),
  updated_at DATETIME DEFAULT SYSDATETIME(),
  );

  -- on pixel change request, check Guest if does not exist and is not a registered user, then create and log the user's ip address

CREATE TABLE Guest (
  id INT IDENTITY(1,1) PRIMARY KEY,
  lastPlace DateTime Null,
  ipAddress varchar(255) NOT NULL
);

-- Column is a reserved keyword hence 'Col'

CREATE TABLE Pixel (
  id INT IDENTITY(1,1) PRIMARY KEY,
  Row SMALLINT NOT NULL,
  Col SMALLINT NOT NULL,
  Color varchar(255) NOT NULL,
  created_at DATETIME NULL DEFAULT SYSDATETIME(),
  updated_at DATETIME NULL DEFAULT SYSDATETIME(),
  updatedBy varchar(255) NULL
);