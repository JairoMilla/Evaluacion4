-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 29-07-2022 a las 00:48:22
-- Versión del servidor: 10.4.24-MariaDB
-- Versión de PHP: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `manga_db`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `autormanga`
--

CREATE TABLE `autormanga` (
  `Id` int(11) NOT NULL,
  `NombreAutor` varchar(250) NOT NULL,
  `FechaNacimiento` date NOT NULL,
  `CantidadObras` int(11) NOT NULL,
  `Activo` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `autormanga`
--

INSERT INTO `autormanga` (`Id`, `NombreAutor`, `FechaNacimiento`, `CantidadObras`, `Activo`) VALUES
(1, 'Takehiko Inoue', '1967-01-12', 7, 1),
(2, 'Yoshihiro Togashi', '1966-04-27', 14, 1),
(3, 'Akira Toriyama', '1955-04-05', 50, 1),
(4, 'Junji Ito', '1963-07-31', 75, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `manga`
--

CREATE TABLE `manga` (
  `Id` int(11) NOT NULL,
  `IdAutor` int(11) NOT NULL,
  `NombreManga` varchar(250) NOT NULL,
  `CantidadTomos` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `manga`
--

INSERT INTO `manga` (`Id`, `IdAutor`, `NombreManga`, `CantidadTomos`) VALUES
(1, 1, 'Slam dunk', 31),
(2, 3, 'Dragon ball ', 42),
(3, 4, 'Uzumaki', 1),
(4, 2, 'Hunter x Hunter', 36),
(5, 3, 'Dr.Slump', 18),
(6, 1, 'Vagabond', 37),
(7, 4, 'Junji Ito\'s Cat Diary: Yon & Mu: Yon & Mu', 1),
(8, 2, 'Yu Yu Hakusho', 19),
(9, 3, 'Dragon ball super', 18),
(10, 1, 'Real', 15),
(11, 4, 'The Liminal Zone', 1),
(12, 2, 'level e', 7),
(13, 3, 'sand land', 1),
(14, 1, 'Piercing', 1),
(15, 1, 'Buzzer Beater', 4),
(16, 1, 'Chameleon Jail', 37),
(17, 1, 'Kaede Purple', 33),
(18, 3, 'Las Aventuras de Tongpoo', 1),
(19, 3, 'Aquí la isla Highlight', 2),
(20, 3, 'Mysterious Rain Jack', 15),
(21, 4, 'Tomie', 3),
(22, 4, 'The Bully', 18),
(23, 4, 'Gyo', 2),
(24, 4, 'Black Paradox', 1),
(25, 4, 'Voices in the Dark', 1),
(26, 4, 'Mold', 18),
(27, 4, 'Army of One', 6),
(28, 4, 'Falling', 1),
(29, 4, 'Dying Young', 18),
(30, 4, 'Frankenstein', 1);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `autormanga`
--
ALTER TABLE `autormanga`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `manga`
--
ALTER TABLE `manga`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IdAutor` (`IdAutor`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `autormanga`
--
ALTER TABLE `autormanga`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `manga`
--
ALTER TABLE `manga`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `manga`
--
ALTER TABLE `manga`
  ADD CONSTRAINT `manga_ibfk_1` FOREIGN KEY (`IdAutor`) REFERENCES `autormanga` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
