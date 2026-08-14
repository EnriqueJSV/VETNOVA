USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_GRAFICO_CITAS_POR_DIA
AS
BEGIN
    BEGIN TRY

        DECLARE @MesActual INT = MONTH(GETDATE());
        DECLARE @AnioActual INT = YEAR(GETDATE());

        ;WITH Dias AS
        (
            SELECT 1 AS NumDia UNION ALL
            SELECT 2 UNION ALL
            SELECT 3 UNION ALL
            SELECT 4 UNION ALL
            SELECT 5 UNION ALL
            SELECT 6 UNION ALL
            SELECT 7 UNION ALL
            SELECT 8 UNION ALL
            SELECT 9 UNION ALL
            SELECT 10 UNION ALL
            SELECT 11 UNION ALL
            SELECT 12 UNION ALL
            SELECT 13 UNION ALL
            SELECT 14 UNION ALL
            SELECT 15 UNION ALL
            SELECT 16 UNION ALL
            SELECT 17 UNION ALL
            SELECT 18 UNION ALL
            SELECT 19 UNION ALL
            SELECT 20 UNION ALL
            SELECT 21 UNION ALL
            SELECT 22 UNION ALL
            SELECT 23 UNION ALL
            SELECT 24 UNION ALL
            SELECT 25 UNION ALL
            SELECT 26 UNION ALL
            SELECT 27 UNION ALL
            SELECT 28 UNION ALL
            SELECT 29 UNION ALL
            SELECT 30 UNION ALL
            SELECT 31
        )

        SELECT
            D.NumDia AS Dia,
            ISNULL(COUNT(C.Id_Cita), 0) AS TotalCitas
        FROM Dias D
        LEFT JOIN Citas C
            ON DAY(C.Fecha) = D.NumDia
           AND MONTH(C.Fecha) = @MesActual
           AND YEAR(C.Fecha) = @AnioActual
        GROUP BY D.NumDia
        ORDER BY D.NumDia;

    END TRY
    BEGIN CATCH

        SELECT
            CAST(NULL AS INT) AS Dia,
            CAST(NULL AS INT) AS TotalCitas
        WHERE 1 = 0;

    END CATCH
END
GO