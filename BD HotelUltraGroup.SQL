/****** Object:  Database [DemoAzure]    Script Date: 1/02/2025 8:56:32 p. m. ******/
CREATE DATABASE [DemoAzure]  (EDITION = 'GeneralPurpose', SERVICE_OBJECTIVE = 'GP_S_Gen5_2', MAXSIZE = 32 GB) WITH CATALOG_COLLATION = SQL_Latin1_General_CP1_CI_AS, LEDGER = OFF;
GO
ALTER DATABASE [DemoAzure] SET COMPATIBILITY_LEVEL = 160
GO
ALTER DATABASE [DemoAzure] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DemoAzure] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DemoAzure] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DemoAzure] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DemoAzure] SET ARITHABORT OFF 
GO
ALTER DATABASE [DemoAzure] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DemoAzure] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DemoAzure] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DemoAzure] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DemoAzure] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DemoAzure] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DemoAzure] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DemoAzure] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DemoAzure] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [DemoAzure] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DemoAzure] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [DemoAzure] SET  MULTI_USER 
GO
ALTER DATABASE [DemoAzure] SET ENCRYPTION ON
GO
ALTER DATABASE [DemoAzure] SET QUERY_STORE = ON
GO
ALTER DATABASE [DemoAzure] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 100, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
/*** The scripts of database scoped configurations in Azure should be executed inside the target database connection. ***/
GO
-- ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 8;
GO
/****** Object:  Schema [hotel]    Script Date: 1/02/2025 8:56:32 p. m. ******/
CREATE SCHEMA [hotel]
GO
/****** Object:  Table [hotel].[City]    Script Date: 1/02/2025 8:56:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [hotel].[City](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [hotel].[DocumentType]    Script Date: 1/02/2025 8:56:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [hotel].[DocumentType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[shortName] [nvarchar](10) NOT NULL,
	[longName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [hotel].[Gender]    Script Date: 1/02/2025 8:56:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [hotel].[Gender](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[gender] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [hotel].[Guests]    Script Date: 1/02/2025 8:56:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [hotel].[Guests](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idReservation] [int] NOT NULL,
	[firstName] [nvarchar](100) NOT NULL,
	[lastName] [nvarchar](100) NOT NULL,
	[idGender] [int] NOT NULL,
	[idDocumentType] [int] NOT NULL,
	[email] [nvarchar](255) NOT NULL,
	[phone] [nvarchar](20) NOT NULL,
	[documentNumber] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK__Guests__3213E83F6079FAB5] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [hotel].[HotelInfo]    Script Date: 1/02/2025 8:56:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [hotel].[HotelInfo](
	[idUser] [int] NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[idCity] [int] NOT NULL,
	[address] [nvarchar](255) NOT NULL,
	[isAvailable] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [hotel].[Reservations]    Script Date: 1/02/2025 8:56:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [hotel].[Reservations](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idHotel] [int] NOT NULL,
	[idRoom] [int] NOT NULL,
	[reservationDate] [datetime] NOT NULL,
	[checkInDate] [datetime] NOT NULL,
	[checkOutDate] [datetime] NOT NULL,
	[guestCount] [int] NOT NULL,
	[fixedNightlyRate] [decimal](10, 2) NOT NULL,
	[fullName] [nvarchar](100) NOT NULL,
	[reservationEmail] [nvarchar](100) NOT NULL,
	[reservationCode] [nvarchar](50) NOT NULL,
	[emergencyContactName] [nvarchar](100) NOT NULL,
	[emergencyContactPhone] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [hotel].[Room]    Script Date: 1/02/2025 8:56:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [hotel].[Room](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idHotel] [int] NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[idRoomType] [int] NOT NULL,
	[nightlyRate] [decimal](10, 2) NOT NULL,
	[isAvailable] [bit] NOT NULL,
	[capacity] [int] NOT NULL,
	[location] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [hotel].[RoomTaxDetail]    Script Date: 1/02/2025 8:56:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [hotel].[RoomTaxDetail](
	[idRoom] [int] NOT NULL,
	[idTax] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idRoom] ASC,
	[idTax] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [hotel].[RoomType]    Script Date: 1/02/2025 8:56:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [hotel].[RoomType](
	[idRoomType] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[description] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[idRoomType] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [hotel].[Tax]    Script Date: 1/02/2025 8:56:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [hotel].[Tax](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[rate] [decimal](5, 2) NOT NULL,
	[description] [nvarchar](255) NULL,
	[idHotel] [int] NOT NULL,
 CONSTRAINT [PK__Tax__24D288393A97A3A3] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [hotel].[users]    Script Date: 1/02/2025 8:56:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [hotel].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](255) NOT NULL,
	[idrol] [int] NOT NULL,
	[email] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__users__email] UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__users__username] UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [hotel].[Room] ADD  DEFAULT ((1)) FOR [isAvailable]
GO
ALTER TABLE [hotel].[Guests]  WITH CHECK ADD  CONSTRAINT [FK__Guests__idDocument] FOREIGN KEY([idDocumentType])
REFERENCES [hotel].[DocumentType] ([id])
GO
ALTER TABLE [hotel].[Guests] CHECK CONSTRAINT [FK__Guests__idDocument]
GO
ALTER TABLE [hotel].[Guests]  WITH CHECK ADD  CONSTRAINT [FK__Guests__idGender] FOREIGN KEY([idGender])
REFERENCES [hotel].[Gender] ([id])
GO
ALTER TABLE [hotel].[Guests] CHECK CONSTRAINT [FK__Guests__idGender]
GO
ALTER TABLE [hotel].[Guests]  WITH CHECK ADD  CONSTRAINT [FK__Guests__idReservation] FOREIGN KEY([idReservation])
REFERENCES [hotel].[Reservations] ([id])
GO
ALTER TABLE [hotel].[Guests] CHECK CONSTRAINT [FK__Guests__idReservation]
GO
ALTER TABLE [hotel].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK__Reservations__HotelInfo] FOREIGN KEY([idHotel])
REFERENCES [hotel].[HotelInfo] ([id])
GO
ALTER TABLE [hotel].[Reservations] CHECK CONSTRAINT [FK__Reservations__HotelInfo]
GO
ALTER TABLE [hotel].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK__Reservations__idRoom] FOREIGN KEY([idRoom])
REFERENCES [hotel].[Room] ([id])
GO
ALTER TABLE [hotel].[Reservations] CHECK CONSTRAINT [FK__Reservations__idRoom]
GO
ALTER TABLE [hotel].[Room]  WITH CHECK ADD  CONSTRAINT [FK__Room__idHotel] FOREIGN KEY([idHotel])
REFERENCES [hotel].[HotelInfo] ([id])
GO
ALTER TABLE [hotel].[Room] CHECK CONSTRAINT [FK__Room__idHotel]
GO
ALTER TABLE [hotel].[Room]  WITH CHECK ADD  CONSTRAINT [FK__Room__idRoomType] FOREIGN KEY([idRoomType])
REFERENCES [hotel].[RoomType] ([idRoomType])
GO
ALTER TABLE [hotel].[Room] CHECK CONSTRAINT [FK__Room__idRoomType]
GO
ALTER TABLE [hotel].[RoomTaxDetail]  WITH CHECK ADD  CONSTRAINT [FK__RoomTaxDe__idRoom] FOREIGN KEY([idRoom])
REFERENCES [hotel].[Room] ([id])
GO
ALTER TABLE [hotel].[RoomTaxDetail] CHECK CONSTRAINT [FK__RoomTaxDe__idRoom]
GO
ALTER TABLE [hotel].[RoomTaxDetail]  WITH CHECK ADD  CONSTRAINT [FK__RoomTaxDe__idTax] FOREIGN KEY([idTax])
REFERENCES [hotel].[Tax] ([id])
GO
ALTER TABLE [hotel].[RoomTaxDetail] CHECK CONSTRAINT [FK__RoomTaxDe__idTax]
GO
ALTER TABLE [hotel].[Tax]  WITH CHECK ADD  CONSTRAINT [FK__Tax__idHotel] FOREIGN KEY([idHotel])
REFERENCES [hotel].[HotelInfo] ([id])
GO
ALTER TABLE [hotel].[Tax] CHECK CONSTRAINT [FK__Tax__idHotel]
GO
/****** Object:  StoredProcedure [hotel].[AssignTaxToRoom]    Script Date: 1/02/2025 8:56:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [hotel].[AssignTaxToRoom]
    @idUser INT,
    @idRoom INT,
    @idTax INT,
    @idHotel INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @existingTaxId INT;

    -- Validar si el idUser tiene permiso en el idHotel
    IF NOT EXISTS (
        SELECT 1 
        FROM [hotel].HotelInfo 
        WHERE id = @idHotel AND idUser = @idUser
    )
    BEGIN
        RAISERROR('El usuario no tiene permiso para asignar impuestos en este hotel.', 16, 1);
        RETURN;
    END

    -- Validar que el impuesto exista en el hotel especificado
    SELECT @existingTaxId = id
    FROM [hotel].Tax
    WHERE id = @idTax AND idHotel = @idHotel;

    IF @existingTaxId IS NULL
    BEGIN
        RAISERROR('El impuesto especificado no existe en el hotel.', 16, 1);
        RETURN;
    END

    -- Comprobar si la relación ya existe entre la habitación y el impuesto
    IF EXISTS (
        SELECT 1 
        FROM [hotel].RoomTaxDetail 
        WHERE idRoom = @idRoom AND idTax = @idTax
    )
    BEGIN
        RAISERROR('El impuesto ya está asignado a la habitación.', 16, 1);
        RETURN;
    END

    -- Asignar el impuesto a la habitación
    INSERT INTO RoomTaxDetail (idRoom, idTax)
    VALUES (@idRoom, @idTax);
END;
GO
/****** Object:  StoredProcedure [hotel].[CreateHotel]    Script Date: 1/02/2025 8:56:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [hotel].[CreateHotel]
    @IdUser INT,
    @name NVARCHAR(100),
    @idCity INT,
    @address NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    -- Validar que el usuario exista
    IF NOT EXISTS (SELECT 1 FROM [hotel].users WHERE id = @IdUser)
    BEGIN
        RAISERROR('El usuario no existe.', 16, 1);
        RETURN;
    END

    -- Validar que la ciudad exista
    IF NOT EXISTS (SELECT 1 FROM [hotel].City WHERE id = @idCity)
    BEGIN
        RAISERROR('La ciudad no existe.', 16, 1);
        RETURN;
    END

    -- Insertar el nuevo hotel
    INSERT INTO HotelInfo (idUser, name, idCity, address, isAvailable)
    VALUES (@IdUser, @name, @idCity, @address, 1); -- Suponiendo que el hotel está disponible por defecto
END;
GO
/****** Object:  StoredProcedure [hotel].[CreateNewUser]    Script Date: 1/02/2025 8:56:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [hotel].[CreateNewUser]
    @username NVARCHAR(50),
    @password NVARCHAR(255),
    @idrol int,
    @email NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    -- Validar si el usuario o el email ya existen
    IF EXISTS (SELECT 1 FROM [hotel].users WHERE username = @username OR email = @email)
    BEGIN
        RAISERROR('Nombre de usuario o email ya se encuentran en uso', 16, 1);
        RETURN;
    END

    -- Insertar nuevo usuario
    INSERT INTO users (username, password, idrol, email)
    VALUES (@username, @password, @idrol, @email);
END;
GO
/****** Object:  StoredProcedure [hotel].[CreateReservation]    Script Date: 1/02/2025 8:56:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [hotel].[CreateReservation]
    @idHotel INT,
    @idRoom INT,
    @checkInDate DATETIME,
    @checkOutDate DATETIME,
    @fullName NVARCHAR(255),
    @email NVARCHAR(255),
    @emergencyContactName NVARCHAR(255),
    @emergencyContactPhone NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @nightlyRate DECIMAL(10, 2);
    DECLARE @reservationCode NVARCHAR(50);
    DECLARE @reservationDate DATETIME = GETDATE();  -- Fecha de reserva se obtiene automáticamente
    DECLARE @numberOfPeople INT; -- Declarar la variable para la cantidad de personas

	   -- Validar que la fecha de check-in sea anterior a la de check-out
       IF CONVERT(DATE, @checkInDate) >= CONVERT(DATE, @checkOutDate)
    BEGIN
        RAISERROR('La fecha de check-in debe ser anterior a la fecha de check-out.', 16, 1);
        RETURN;
    END


    -- Validación de disponibilidad de la habitación y que pertenezca al hotel
    DECLARE @availability INT;
    SELECT @availability = COUNT(*) 
    FROM [hotel].Room 
    WHERE id = @idRoom AND isAvailable = 1 AND idHotel = @idHotel;  -- Validar que la habitación sea del hotel

    IF @availability = 0
    BEGIN
        RAISERROR('La habitación no está disponible o no pertenece al hotel especificado.', 16, 1);
        RETURN;
    END

    -- Obtener la capacidad (número de personas) y la tarifa por noche de la habitación en un solo SELECT
    SELECT @numberOfPeople = capacity, @nightlyRate = nightlyRate 
    FROM [hotel].Room 
    WHERE id = @idRoom;

    -- Validar que no haya otra reserva en la misma habitación dentro de las fechas seleccionadas
    DECLARE @conflictingReservations INT;
    SELECT @conflictingReservations = COUNT(*) 
    FROM [hotel].Reservations
    WHERE idRoom = @idRoom 
      AND ((@checkInDate >= checkInDate AND @checkInDate < checkOutDate) OR
           (@checkOutDate > checkInDate AND @checkOutDate <= checkOutDate) OR
           (checkInDate >= @checkInDate AND checkInDate < @checkOutDate));

    IF @conflictingReservations > 0
    BEGIN
        RAISERROR('Ya existe una reserva en esta habitación para las fechas seleccionadas.', 16, 1);
        RETURN;
    END

    -- Generar un código de reserva (puedes ajustar la lógica según lo necesites)
    SET @reservationCode = CONVERT(NVARCHAR(50), NEWID());  -- Genera un GUID como código de reserva

    -- Inserción de la nueva reserva
    INSERT INTO Reservations (idHotel, idRoom, reservationDate, checkInDate, checkOutDate, fullName, reservationEmail, reservationCode, emergencyContactName, emergencyContactPhone, guestCount, fixedNightlyRate)
    VALUES (@idHotel, @idRoom, @reservationDate, @checkInDate, @checkOutDate, @fullName, @email, @reservationCode, @emergencyContactName, @emergencyContactPhone, @numberOfPeople, @nightlyRate);
  -- Devolver el código de reserva asignado
    SELECT @reservationCode AS reservationCode;

END;
GO
/****** Object:  StoredProcedure [hotel].[CreateRoom]    Script Date: 1/02/2025 8:56:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [hotel].[CreateRoom]
    @idUser INT,
    @idHotel INT,
    @idRoomType INT,
	@name NVARCHAR(100),
    @location NVARCHAR(100),
    @nightlyRate DECIMAL(10, 2),
    @isAvailable BIT,
    @capacity INT
AS
BEGIN
    SET NOCOUNT ON;


    IF NOT EXISTS (SELECT 1 FROM [hotel].HotelInfo WHERE id = @IdHotel AND IdUser = @idUser)
    BEGIN
        RAISERROR('El hotel especificado no existe o el usuario no tiene permisos.', 16, 1);
        RETURN;
    END

    -- Validación de la existencia del Tipo de Habitación
    IF NOT EXISTS (SELECT 1 FROM [hotel].RoomType WHERE idRoomType = @idRoomType)
    BEGIN
        RAISERROR('El tipo de habitación especificado no existe.', 16, 1);
        RETURN;
    END

    INSERT INTO Room (IdHotel,name, idRoomType, Location, NightlyRate, IsAvailable, Capacity)
    VALUES (@IdHotel,@name, @idRoomType, @Location, @NightlyRate, @IsAvailable, @Capacity);
END;
GO
/****** Object:  StoredProcedure [hotel].[CreateTax]    Script Date: 1/02/2025 8:56:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [hotel].[CreateTax]
    @idUser INT,
    @idHotel INT,
    @name NVARCHAR(100),
    @rate DECIMAL(5, 2),
    @description NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    -- Validación de límite para la tasa del impuesto
    IF @Rate < 0 OR @Rate > 100
    BEGIN
        RAISERROR('La tasa de impuesto debe estar entre 0 y 100.', 16, 1);
        RETURN;
    END

    -- Validar si el idUser tiene permiso en el idHotel
    IF NOT EXISTS (
        SELECT 1 
        FROM [hotel].HotelInfo 
        WHERE id = @idHotel AND idUser = @idUser
    )
    BEGIN
        RAISERROR('El usuario no tiene permiso para crear impuestos en este hotel.', 16, 1);
        RETURN;
    END

    -- Inserción del nuevo tipo de impuesto
    INSERT INTO Tax (idHotel, name, rate, description)
    VALUES (@idHotel, @name, @rate, @description);
END;
GO
/****** Object:  StoredProcedure [hotel].[GetAvailableHotelRooms]    Script Date: 1/02/2025 8:56:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [hotel].[GetAvailableHotelRooms]
    @idHotel INT,
    @checkInDate DATETIME,
    @checkOutDate DATETIME,
    @numberOfPeople INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT r.id AS idRoom,
           r.name AS RoomName,
           r.capacity,
           r.nightlyRate,
           r.isAvailable
    FROM [hotel].Room r
    WHERE r.idHotel = @idHotel
      AND r.isAvailable = 1  -- Solo habitaciones disponibles
      AND r.capacity >= @numberOfPeople  -- Filtrar por capacidad
      AND NOT EXISTS (
          SELECT 1
          FROM [hotel].Reservations res
          WHERE res.idRoom = r.id
            AND ((@checkInDate >= res.checkInDate AND @checkInDate < res.checkOutDate) OR
                 (@checkOutDate > res.checkInDate AND @checkOutDate <= res.checkOutDate) OR
                 (res.checkInDate >= @checkInDate AND res.checkInDate < @checkOutDate))
      );
END;
GO
/****** Object:  StoredProcedure [hotel].[GetAvailableHotels]    Script Date: 1/02/2025 8:56:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [hotel].[GetAvailableHotels]
    @checkInDate DATETIME,
    @checkOutDate DATETIME,
    @numberOfPeople INT,
    @idCity INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Validar que la fecha de check-in sea anterior a la de check-out
    IF @checkInDate >= @checkOutDate
    BEGIN
        RAISERROR('La fecha de check-in debe ser anterior a la de check-out.', 16, 1);
        RETURN;
    END

    SELECT DISTINCT h.id AS HotelId,
                    h.name AS HotelName,
                    h.idCity AS idCity,
                    h.address AS Address
    FROM [hotel].HotelInfo h
    JOIN [hotel].Room r ON h.id = r.idHotel
    WHERE r.isAvailable = 1  -- Solo habitaciones disponibles
      AND h.idCity = @idCity  -- Filtrar por ciudad
      AND r.capacity >= @numberOfPeople  -- Filtrar por capacidad
      AND NOT EXISTS (
          SELECT 1
          FROM [hotel].Reservations res
          WHERE res.idRoom = r.id
            AND ((@checkInDate >= res.checkInDate AND @checkInDate < res.checkOutDate) OR
                 (@checkOutDate > res.checkInDate AND @checkOutDate <= res.checkOutDate) OR
                 (res.checkInDate >= @checkInDate AND res.checkInDate < @checkOutDate))
      );  -- Asegurarse de que no haya reservas en conflicto
END;
GO
/****** Object:  StoredProcedure [hotel].[GetCityList]    Script Date: 1/02/2025 8:56:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [hotel].[GetCityList]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT id AS idCity,
           name AS cityName
    FROM [hotel].City;
END;

GO
/****** Object:  StoredProcedure [hotel].[GetDocumentTypeList]    Script Date: 1/02/2025 8:56:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [hotel].[GetDocumentTypeList]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT id AS idDocumentType,
           shortName AS documentTypeName,
		   longName  as description
    FROM [hotel].DocumentType;
END;
GO
/****** Object:  StoredProcedure [hotel].[GetGenderList]    Script Date: 1/02/2025 8:56:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [hotel].[GetGenderList]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT id AS idGender,
           gender AS genderName
    FROM [hotel].Gender;
END;
GO
/****** Object:  StoredProcedure [hotel].[GetHotels]    Script Date: 1/02/2025 8:56:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [hotel].[GetHotels]
    @idUser INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Seleccionar hoteles donde el usuario tiene permisos
    SELECT 		
        h.id as idHotel,
        h.name,
        h.idCity,
		c.name as namecity,
        h.address,
        h.isAvailable
    FROM [hotel].
        HotelInfo h
	INNER JOIN [hotel].City c on c.id=h.idCity
    WHERE 
        idUser = @idUser;
END;
GO
/****** Object:  StoredProcedure [hotel].[GetHotelTaxes]    Script Date: 1/02/2025 8:56:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [hotel].[GetHotelTaxes]
    @idHotel INT,
    @idUser INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Validar que el usuario tenga permisos en el hotel
    IF NOT EXISTS (
        SELECT 1 
        FROM [hotel].HotelInfo 
        WHERE id = @idHotel AND idUser = @idUser
    )
    BEGIN
        RAISERROR('El usuario no tiene permisos para acceder a la información de este hotel.', 16, 1);
        RETURN;
    END

    -- Obtener información de impuestos del hotel
    SELECT id AS TaxId,
           name AS TaxName,
           rate AS TaxRate,
           description AS TaxDescription
    FROM [hotel].Tax
    WHERE idHotel = @idHotel;
END;
GO
/****** Object:  StoredProcedure [hotel].[GetReservationDetail]    Script Date: 1/02/2025 8:56:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [hotel].[GetReservationDetail]
    @reservationId INT,
    @userId INT,
    @hotelId INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Verificar que el usuario tenga permisos sobre el hotel especificado
    IF EXISTS (
        SELECT 1
        FROM [hotel].HotelInfo h
        WHERE h.id = @hotelId
          AND h.idUser = @userId
    )
    BEGIN
        -- Obtener detalles de la reserva, habitación, capacidad y calcular el valor total y valor total con impuestos
        SELECT 
            r.id AS ReservationId,
            r.reservationCode AS ReservationCode,
            r.checkInDate AS CheckInDate,
            r.checkOutDate AS CheckOutDate,
            r.fullName AS GuestName,
            r.reservationEmail AS GuestEmail,
            ro.name AS RoomName,
            ro.nightlyRate AS NightlyRate,
            ro.capacity AS MaxGuestsAllowed,
            ro.location AS RoomLocation,
            DATEDIFF(DAY, r.checkInDate, r.checkOutDate) AS StayDuration,
            -- Calcular el valor total sin impuestos
            DATEDIFF(DAY, r.checkInDate, r.checkOutDate) * ro.nightlyRate AS ValorTotal,
            -- Calcular el valor total con impuestos
            DATEDIFF(DAY, r.checkInDate, r.checkOutDate) * ro.nightlyRate * 
            (1 + ISNULL(SUM(t.rate / 100), 0)) AS ValorTotalConImpuestos
        FROM [hotel].
            Reservations r
        INNER JOIN 
            [hotel].Room ro ON r.idRoom = ro.id
        LEFT JOIN 
            [hotel].RoomTaxDetail rtd ON ro.id = rtd.idRoom
        LEFT JOIN 
            [hotel].Tax t ON rtd.idTax = t.id
        WHERE 
            r.id = @reservationId
            AND r.idHotel = @hotelId
        GROUP BY 
            r.id, r.reservationCode, r.checkInDate, r.checkOutDate, r.fullName, r.reservationEmail,
            ro.name, ro.nightlyRate, ro.capacity, ro.location;
    END
    ELSE
    BEGIN
        -- Si el usuario no tiene permiso, retorna un mensaje de error
        RAISERROR ('No tienes permisos para ver los detalles de esta reserva.', 16, 1);
    END
END;
GO
/****** Object:  StoredProcedure [hotel].[GetReservationsByUserAndHotel]    Script Date: 1/02/2025 8:56:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [hotel].[GetReservationsByUserAndHotel]
    @userId INT,
    @hotelId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        r.id AS idReservation,
        r.reservationCode AS reservationCode,
        r.checkInDate AS checkInDate,
        r.checkOutDate AS checkOutDate,
        r.fullName AS fullName,
        r.reservationEmail AS reservationEmail
    FROM [hotel].
        Reservations r
    INNER JOIN 
        [hotel].HotelInfo h ON r.idHotel = h.id    
    WHERE 
        h.idUser = @userId
        AND h.id = @hotelId
    ORDER BY 
        r.reservationDate DESC;
END;
GO
/****** Object:  StoredProcedure [hotel].[GetRoomsByHotel]    Script Date: 1/02/2025 8:56:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [hotel].[GetRoomsByHotel]
    @idHotel INT,
    @idUser INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Validación de permisos de acceso del usuario al hotel
    IF NOT EXISTS (
        SELECT 1
        FROM [hotel].HotelInfo
        WHERE id = @idHotel AND idUser = @idUser
    )
    BEGIN
        RAISERROR('No tiene permiso para ver las habitaciones de este hotel.', 16, 1);
        RETURN;
    END

    -- Selección de habitaciones con sus respectivos tipos
    SELECT 
        r.id,
        r.name AS RoomName,
        r.nightlyRate,
        r.isAvailable,
        r.capacity,
        r.location,
        rt.name AS RoomTypeName
    FROM [hotel].
        Room r
    INNER JOIN 
        [hotel].RoomType rt ON r.idRoomType = rt.idRoomType
    WHERE 
        r.idHotel = @idHotel;
END;
GO
/****** Object:  StoredProcedure [hotel].[GetUserAccess]    Script Date: 1/02/2025 8:56:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [hotel].[GetUserAccess]
    @username NVARCHAR(50),
    @password NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT id
    FROM [hotel].users
    WHERE username = @username AND  password = @password COLLATE Latin1_General_BIN;  
END;
GO
/****** Object:  StoredProcedure [hotel].[RegisterGuest]    Script Date: 1/02/2025 8:56:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [hotel].[RegisterGuest]
    @reservationCode NVARCHAR(50),
    @firstName NVARCHAR(100),
    @lastName NVARCHAR(100),
    @idGender INT,
    @idDocumentType INT,
    @documentNumber NVARCHAR(255), -- Ahora es obligatorio
    @email NVARCHAR(255),
    @phone NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @idReservation INT;
    DECLARE @currentGuestCount INT;
    DECLARE @maxGuestCount INT;

    -- Validar que el tipo de documento existe
    IF NOT EXISTS (SELECT 1 FROM [hotel].DocumentType WHERE id = @idDocumentType)
    BEGIN
        RAISERROR('El tipo de documento especificado no es válido.', 16, 1);
        RETURN;
    END

    -- Validar que el género existe
    IF NOT EXISTS (SELECT 1 FROM [hotel].Gender WHERE id = @idGender)
    BEGIN
        RAISERROR('El género especificado no es válido.', 16, 1);
        RETURN;
    END

    -- Obtener el ID de la reserva usando el reservationCode
    SELECT @idReservation = id
    FROM [hotel].Reservations
    WHERE reservationCode = @reservationCode;

    -- Validar que se haya encontrado la reserva
    IF @idReservation IS NULL
    BEGIN
        RAISERROR('No se encontró una reserva con el código especificado.', 16, 1);
        RETURN;
    END

    -- Obtener la cantidad actual de huéspedes de la reserva
    SELECT @currentGuestCount = COUNT(*)
    FROM [hotel].Guests
    WHERE idReservation = @idReservation;

    -- Obtener la capacidad máxima de huéspedes de la reserva
    SELECT @maxGuestCount = guestCount
    FROM [hotel].Reservations
    WHERE id = @idReservation;

    -- Validar que la cantidad de huéspedes no supere el límite
    IF @currentGuestCount >= @maxGuestCount
    BEGIN
        RAISERROR('No se puede registrar más huéspedes. El límite de huéspedes para esta reserva ya ha sido alcanzado.', 16, 1);
        RETURN;
    END

	   -- Validar que no exista ya un huésped con el mismo tipo y número de documento en esta reserva
    IF EXISTS (SELECT 1 
               FROM [hotel].Guests 
               WHERE idReservation = @idReservation 
                 AND idDocumentType = @idDocumentType 
                 AND documentNumber = @documentNumber)
    BEGIN
        RAISERROR('El huésped ya está registrado con el mismo tipo y número de documento para esta reserva.', 16, 1);
        RETURN;
    END

    -- Inserción del nuevo huésped, incluyendo DocumentNumber como obligatorio
    INSERT INTO Guests (firstName, lastName, idGender, idDocumentType, documentNumber, email, phone, idReservation)
    VALUES (@firstName, @lastName, @idGender, @idDocumentType, @documentNumber, @email, @phone, @idReservation);
END;
GO
/****** Object:  StoredProcedure [hotel].[RemoveTaxFromRoom]    Script Date: 1/02/2025 8:56:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [hotel].[RemoveTaxFromRoom]
    @idUser INT,
    @idRoom INT,
    @idTax INT,
    @idHotel INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Validar si el idUser tiene permiso en el idHotel
    IF NOT EXISTS (
        SELECT 1 
        FROM [hotel].HotelInfo 
        WHERE id = @idHotel AND idUser = @idUser
    )
    BEGIN
        RAISERROR('El usuario no tiene permiso para eliminar impuestos de este hotel.', 16, 1);
        RETURN;
    END

    -- Comprobar si la relación existe
    IF NOT EXISTS (
        SELECT 1 
        FROM [hotel].RoomTaxDetail 
        WHERE idRoom = @idRoom AND idTax = @idTax
    )
    BEGIN
        RAISERROR('El impuesto no está asignado a la habitación.', 16, 1);
        RETURN;
    END

    -- Eliminar el impuesto de la habitación
    DELETE FROM [hotel].RoomTaxDetail 
    WHERE idRoom = @idRoom AND idTax = @idTax;
END;
GO
/****** Object:  StoredProcedure [hotel].[UpdateHotel]    Script Date: 1/02/2025 8:56:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [hotel].[UpdateHotel]
    @idHotel INT,
    @idUser INT,
    @name NVARCHAR(100),
    @idCity INT,
    @address NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    -- Validar que el hotel exista
    IF NOT EXISTS (SELECT 1 FROM [hotel].HotelInfo WHERE id = @idHotel)
    BEGIN
        RAISERROR('El hotel no existe.', 16, 1);
        RETURN;
    END

    -- Validar que el usuario que intenta actualizar sea el propietario del hotel
    IF NOT EXISTS (SELECT 1 FROM [hotel].HotelInfo WHERE id = @idHotel AND idUser = @idUser)
    BEGIN
        RAISERROR('No tienes permiso para actualizar este hotel.', 16, 1);
        RETURN;
    END

    -- Actualizar la información del hotel
    UPDATE HotelInfo
    SET name = @name,
        idCity = @idCity,
        address = @address
    WHERE id = @idHotel;
END;
GO
/****** Object:  StoredProcedure [hotel].[UpdateRoom]    Script Date: 1/02/2025 8:56:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [hotel].[UpdateRoom]
    @IdUser INT,
    @IdRoom INT,
    @IdHotel INT,
    @idRoomType INT,
	@name NVARCHAR(100),
    @Location NVARCHAR(100),
    @NightlyRate DECIMAL(10, 2),
    @Capacity INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Validación de existencia y permiso del usuario en el hotel
    IF NOT EXISTS (SELECT 1 FROM [hotel].HotelInfo WHERE Id = @IdHotel AND IdUser = @IdUser)
    BEGIN
        RAISERROR('El hotel especificado no existe o el usuario no tiene permisos.', 16, 1);
        RETURN;
    END

    -- Validación de existencia de la habitación en el hotel especificado
    IF NOT EXISTS (SELECT 1 FROM [hotel].Room WHERE Id = @IdRoom AND IdHotel = @IdHotel)
    BEGIN
        RAISERROR('La habitación especificada no existe en el hotel indicado.', 16, 1);
        RETURN;
    END

    -- Actualización de la habitación
    UPDATE Room
    SET idRoomType = @idRoomType,
		name = @name,
        Location = @Location,
        NightlyRate = @NightlyRate,
        Capacity = @Capacity
    WHERE Id = @IdRoom;
END;
GO
/****** Object:  StoredProcedure [hotel].[UpdateRoomStatus]    Script Date: 1/02/2025 8:56:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [hotel].[UpdateRoomStatus]
    @IdUser INT,
    @idHotel INT,
    @idRoom INT,
    @isAvailable BIT
AS
BEGIN
    SET NOCOUNT ON;

    -- Validación de permisos: verifica si el usuario tiene acceso al hotel y que la habitación pertenezca al hotel especificado
    IF NOT EXISTS (
        SELECT 1 
        FROM [hotel].Room r
        INNER JOIN [hotel].HotelInfo h ON r.IdHotel = h.Id
        WHERE r.Id = @idRoom AND r.IdHotel = @idHotel AND h.IdUser = @IdUser
    )
    BEGIN
        RAISERROR('No tiene permisos para actualizar esta habitación.', 16, 1);
        RETURN;
    END

    -- Actualización del estado de la habitación
    UPDATE Room
    SET IsAvailable = @IsAvailable
    WHERE Id = @idRoom AND IdHotel = @idHotel;
END;
GO
/****** Object:  StoredProcedure [hotel].[UpdateStatusHotel]    Script Date: 1/02/2025 8:56:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [hotel].[UpdateStatusHotel]
    @idHotel INT,
    @idUser INT,
    @isAvailable BIT
AS
BEGIN
    SET NOCOUNT ON;

    -- Validar que el hotel exista
    IF NOT EXISTS (SELECT 1 FROM [hotel].HotelInfo WHERE id = @idHotel)
    BEGIN
        RAISERROR('El hotel no existe.', 16, 1);
        RETURN;
    END

    -- Validar que el usuario que intenta actualizar sea el propietario del hotel
    IF NOT EXISTS (SELECT 1 FROM [hotel].HotelInfo WHERE id = @idHotel AND idUser = @idUser)
    BEGIN
        RAISERROR('No tienes permiso para actualizar el estado de este hotel.', 16, 1);
        RETURN;
    END

    -- Actualizar el estado de disponibilidad del hotel
    UPDATE HotelInfo
    SET isAvailable = @isAvailable
    WHERE id = @idHotel;
END;
GO
/****** Object:  StoredProcedure [hotel].[UpdateTax]    Script Date: 1/02/2025 8:56:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [hotel].[UpdateTax]
    @idUser INT,
    @idTax INT,
    @idHotel INT,
    @name NVARCHAR(100),
    @rate DECIMAL(5, 2),
    @description NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @existingTaxId INT;

    -- Validación de límite para la tasa del impuesto
    IF @Rate < 0 OR @Rate > 100
    BEGIN
        RAISERROR('La tasa de impuesto debe estar entre 0 y 100.', 16, 1);
        RETURN;
    END

    -- Validar si el idUser tiene permiso en el idHotel
    IF NOT EXISTS (
        SELECT 1 
        FROM [hotel].HotelInfo 
        WHERE id = @idHotel AND idUser = @idUser
    )
    BEGIN
        RAISERROR('El usuario no tiene permiso para actualizar impuestos en este hotel.', 16, 1);
        RETURN;
    END

    -- Validación de existencia de idTax e idHotel en la tabla Tax
    SELECT @existingTaxId = id
    FROM [hotel].Tax
    WHERE id = @idTax AND idHotel = @idHotel;

    IF @existingTaxId IS NULL
    BEGIN
        RAISERROR('El impuesto especificado no existe en el hotel.', 16, 1);
        RETURN;
    END

    -- Actualización del tipo de impuesto
    UPDATE Tax
    SET name = @name,
        rate = @rate,
        description = @description
    WHERE id = @existingTaxId;
END;
GO
ALTER DATABASE [DemoAzure] SET  READ_WRITE 
GO
