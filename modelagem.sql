CREATE DATABASE dbclientes;

USE dbclientes;

CREATE TABLE clientes (
    ID_Cliente INT(11) NOT NULL AUTO_INCREMENT,
    Nome VARCHAR(100) NOT NULL,
    Endereco VARCHAR(255) NOT NULL,
    Telefone VARCHAR (20) NOT NULL,
    RG VARCHAR(20) NOT NULL,
    CPF VARCHAR(20) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    PRIMARY KEY (ID_Cliente)
);

DELIMITER //

CREATE TRIGGER befor_clientes_insert
BEFOR INSERT ON clientes
FOR EACH ROW
BEGIN
    DECLARE invalid_format BOOLEAN ;
/* Validacao RG e CPF */
    SET invalid_format = NEW.CPF NOT REGEXP '^[0-9]{11}$';
    IF invalid_format THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Invalid CPF Format. IT shold be 9 digits.';
    END IF;

    SET invalid_format = NEW.RG NOT REGEXP '^[0-9]{9}$';
    IF invalid_format THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Invalid RG Format. IT shold be 9 digits.';
    END IF;
END
DEMILITER ;

// Modelagem de Dados

// Execucao SQL

// Instalar a dependencia dotnet add package MySQL.Data

// Criacao da classe Cliente.cs