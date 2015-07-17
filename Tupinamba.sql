-- phpMyAdmin SQL Dump
-- version 2.11.2.2
-- http://www.phpmyadmin.net
--
-- Servidor: localhost:3306
-- Tempo de Geração: Jun 06, 2014 as 10:33 AM
-- Versão do Servidor: 5.0.45
-- Versão do PHP: 5.2.5

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";

--
-- Banco de Dados: `tupinamba`
--
CREATE DATABASE `tupinamba` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `tupinamba`;

-- --------------------------------------------------------

--
-- Estrutura da tabela `cliente`
--

CREATE TABLE IF NOT EXISTS `cliente` (
  `CliCPF` int(11) NOT NULL,
  `CliNome` varchar(20) NOT NULL,
  `CliEmail` varchar(30) NOT NULL,
  `CliTel` int(11) NOT NULL,
  `CliRot` varchar(20) NOT NULL,
  `CliDet` int(11) NOT NULL,
  PRIMARY KEY  (`CliCPF`),
  KEY `CliTel` (`CliTel`),
  KEY `CliDet` (`CliDet`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `cliente`
--

INSERT INTO `cliente` (`CliCPF`, `CliNome`, `CliEmail`, `CliTel`, `CliRot`, `CliDet`) VALUES
(2147483647, 'Ana rosa', 'anarosa@gmail.com.br', 2147483647, 'Praias', 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `contratos`
--

CREATE TABLE IF NOT EXISTS `contratos` (
  `ContC` char(14) NOT NULL,
  `ContNome` varchar(20) NOT NULL,
  `ContEnd` int(11) NOT NULL,
  `ContTel` int(11) NOT NULL,
  `ContTipo` varchar(10) NOT NULL,
  PRIMARY KEY  (`ContC`),
  KEY `ContEnd` (`ContEnd`),
  KEY `ContTel` (`ContTel`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `contratos`
--


-- --------------------------------------------------------

--
-- Estrutura da tabela `fluxocaixa`
--

CREATE TABLE IF NOT EXISTS `fluxocaixa` (
  `FluCod` int(11) NOT NULL,
  `FluGanho` varchar(100) NOT NULL,
  `FluGasto` varchar(100) NOT NULL,
  `FluData` date NOT NULL,
  PRIMARY KEY  (`FluCod`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `fluxocaixa`
--

INSERT INTO `fluxocaixa` (`FluCod`, `FluGanho`, `FluGasto`, `FluData`) VALUES
(1, '180.00', '80.00', '2014-04-28'),
(2, '200,00', '100,00', '2014-04-29'),
(3, '150,00', '55,00', '2014-05-22'),
(4, '200', '100', '2014-05-22'),
(5, '122', '312', '2014-05-22'),
(6, '2323', '322', '2014-05-22'),
(7, '3232', '432', '2014-05-22'),
(8, '54543', '323', '2014-05-22'),
(9, '532', '342', '2014-05-22'),
(10, '543', '232', '2014-05-22'),
(12, '3243', '432', '2014-05-22'),
(13, '532', '432', '2014-05-22'),
(14, '423', '42', '2014-05-22'),
(15, '42', '43', '2014-05-22'),
(16, '432', '33', '2014-05-22'),
(17, '423', '43', '2014-05-22'),
(18, '432', '43', '2014-05-22'),
(19, '423', '32', '2014-05-22'),
(20, '3243', '342', '2014-05-22'),
(21, '432', '43', '2014-05-22'),
(22, '45126', '45', '2014-05-22'),
(23, '423', '43', '2014-05-22'),
(24, '4324', '43', '2014-05-22'),
(25, '43243', '43', '2014-05-22'),
(26, '4342', '43', '2014-05-22'),
(27, '423', '432', '2014-05-22'),
(28, '234', '432', '2014-05-22'),
(29, '43', '43', '2014-05-22'),
(30, '432', '432', '2014-05-22'),
(31, '432', '432', '2014-05-22'),
(32, '423', '432', '2014-05-22'),
(33, '432', '432', '2014-05-22'),
(34, '423', '423', '2014-05-22'),
(35, '432', '432', '2014-05-22'),
(36, '453', '543', '2014-05-22'),
(37, '432', '432', '2014-05-22'),
(38, '432', '432', '2014-05-22'),
(39, '432', '432', '2014-05-22'),
(40, '34', '22', '2014-05-22'),
(41, '211', '43', '2014-05-22'),
(42, '200,00', '100,00', '2014-06-01'),
(43, '120,00', '50,00', '2014-06-06');

-- --------------------------------------------------------

--
-- Estrutura da tabela `funcionario`
--

CREATE TABLE IF NOT EXISTS `funcionario` (
  `FuncCPF` char(11) NOT NULL,
  `FuncNome` varchar(20) NOT NULL,
  `FuncRG` char(9) NOT NULL,
  `FuncRes` int(11) NOT NULL,
  `FuncEmail` varchar(30) NOT NULL,
  `FuncArea` varchar(20) NOT NULL,
  `FuncTel` int(11) NOT NULL,
  PRIMARY KEY  (`FuncCPF`),
  KEY `FuncRes` (`FuncRes`),
  KEY `FuncTel` (`FuncTel`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `funcionario`
--


-- --------------------------------------------------------

--
-- Estrutura da tabela `reserva`
--

CREATE TABLE IF NOT EXISTS `reserva` (
  `ReseCod` int(11) NOT NULL,
  `ReseData` date NOT NULL,
  `ReseAdu` int(11) NOT NULL,
  `ReseCri` int(11) NOT NULL,
  `ReseHospe` varchar(10) NOT NULL,
  `ReseDiar` int(11) NOT NULL,
  `ReseTransp` varchar(10) NOT NULL,
  `ResePassag` int(11) default NULL,
  `ReseSeguro` varchar(3) NOT NULL,
  `ReseAlim` varchar(20) NOT NULL,
  `ResePaga` varchar(20) NOT NULL,
  `ReseFPreco` varchar(20) NOT NULL,
  `ReseAdic` varchar(200) default NULL,
  `ReseObs` varchar(200) default NULL,
  `ResePerfil` varchar(20) NOT NULL,
  PRIMARY KEY  (`ReseCod`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `reserva`
--

INSERT INTO `reserva` (`ReseCod`, `ReseData`, `ReseAdu`, `ReseCri`, `ReseHospe`, `ReseDiar`, `ReseTransp`, `ResePassag`, `ReseSeguro`, `ReseAlim`, `ResePaga`, `ReseFPreco`, `ReseAdic`, `ReseObs`, `ResePerfil`) VALUES
(1, '2014-07-09', 1, 0, 'Nao precis', 0, 'Nao.', 0, 'Nao', 'Lanche de trilha/ pe', 'Boleto bancario', 'de 50,00 a 100,00', 'nada', 'nenhuma', 'Solteiros');

-- --------------------------------------------------------

--
-- Estrutura da tabela `residencia`
--

CREATE TABLE IF NOT EXISTS `residencia` (
  `ResCod` int(11) NOT NULL,
  `ResNumero` varchar(5) NOT NULL,
  `ResRua` varchar(90) NOT NULL,
  `ResCompl` varchar(20) default NULL,
  `ResBairro` varchar(90) NOT NULL,
  `ResCidade` varchar(90) NOT NULL,
  `ResEstado` varchar(2) NOT NULL,
  `ResCEP` char(8) NOT NULL,
  PRIMARY KEY  (`ResCod`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `residencia`
--

INSERT INTO `residencia` (`ResCod`, `ResNumero`, `ResRua`, `ResCompl`, `ResBairro`, `ResCidade`, `ResEstado`, `ResCEP`) VALUES
(1, '123', 'mendes', 'andar 2', 'Salgueiro', 'Diadema', 'Sã', '45348763'),
(2, '343', 'Anagua', '2', 'Segi', 'São Paulo', 'Sã', '23546787');

-- --------------------------------------------------------

--
-- Estrutura da tabela `roteiros`
--

CREATE TABLE IF NOT EXISTS `roteiros` (
  `RotCod` int(11) NOT NULL,
  `RotLocal` varchar(100) NOT NULL,
  `RotAtrac` varchar(500) NOT NULL,
  `RotDura` varchar(50) NOT NULL,
  `RotValor` varchar(20) NOT NULL,
  `RotInclu` varchar(150) NOT NULL,
  `RotCrono` varchar(500) NOT NULL,
  `RotFunc` varchar(20) NOT NULL,
  `RotNome` varchar(30) NOT NULL,
  `RotTipo` varchar(30) NOT NULL,
  PRIMARY KEY  (`RotCod`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `roteiros`
--

INSERT INTO `roteiros` (`RotCod`, `RotLocal`, `RotAtrac`, `RotDura`, `RotValor`, `RotInclu`, `RotCrono`, `RotFunc`, `RotNome`, `RotTipo`) VALUES
(1, 'peruibe', 'estrelas do mar', '1 hora', '50,00', 'lanche', '13;00 saida 15:00 chegada', 'Paulio', 'Praia mangue', 'Praias');

-- --------------------------------------------------------

--
-- Estrutura da tabela `senha`
--

CREATE TABLE IF NOT EXISTS `senha` (
  `SUsu` varchar(10) NOT NULL,
  `SSen` varchar(10) NOT NULL,
  `SCPF` char(11) NOT NULL,
  PRIMARY KEY  (`SCPF`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `senha`
--

INSERT INTO `senha` (`SUsu`, `SSen`, `SCPF`) VALUES
('Admin', '123adm', '12345678901');

-- --------------------------------------------------------

--
-- Estrutura da tabela `telefone`
--

CREATE TABLE IF NOT EXISTS `telefone` (
  `TelCod` int(11) NOT NULL,
  `TelCel` char(11) NOT NULL,
  `TelResi` char(10) default NULL,
  `TelComercial` char(10) default NULL,
  PRIMARY KEY  (`TelCod`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `telefone`
--

INSERT INTO `telefone` (`TelCod`, `TelCel`, `TelResi`, `TelComercial`) VALUES
(1, '987128312', '40403423', '40132356'),
(2, '987675656', '40509887', '40986756'),
(2147483647, '40495656', '989797878', NULL);

--
-- Restrições para as tabelas dumpadas
--

--
-- Restrições para a tabela `contratos`
--
ALTER TABLE `contratos`
  ADD CONSTRAINT `contratos_ibfk_1` FOREIGN KEY (`ContEnd`) REFERENCES `residencia` (`ResCod`),
  ADD CONSTRAINT `contratos_ibfk_2` FOREIGN KEY (`ContTel`) REFERENCES `telefone` (`TelCod`);

--
-- Restrições para a tabela `funcionario`
--
ALTER TABLE `funcionario`
  ADD CONSTRAINT `funcionario_ibfk_1` FOREIGN KEY (`FuncRes`) REFERENCES `residencia` (`ResCod`),
  ADD CONSTRAINT `funcionario_ibfk_2` FOREIGN KEY (`FuncTel`) REFERENCES `telefone` (`TelCod`);
