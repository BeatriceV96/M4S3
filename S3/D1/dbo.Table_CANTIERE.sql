CREATE TABLE [dbo].[Table CANTIERE] (
    [Id]                    INT            IDENTITY (1, 1) NOT NULL,
    [DenominazioneCantiere] NVARCHAR (50)  NOT NULL,
    [Indirizzo]             NVARCHAR (100) NOT NULL,
    [Città]                 NVARCHAR (50)  NOT NULL,
    [CAP]                   CHAR (50)      NOT NULL,
    [PersonaRiferimento]    NVARCHAR (50)  NOT NULL,
    [DataInizioLavori]      DATETIME2           NOT NULL,
    [DataFineLavori]        DATETIME2           NOT NULL,
    [ LavoriTerminatiSI_NO] BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

