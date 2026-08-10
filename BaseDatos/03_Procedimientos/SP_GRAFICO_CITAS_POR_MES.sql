USE VetNova
GO

CREATE OR ALTER PROCEDURE SP_GRAFICO_CITAS_POR_MES
AS
BEGIN
    BEGIN TRY

        ;WITH Meses AS
        (
            SELECT 1 AS NumMes, 'Enero' AS Mes UNION ALL
            SELECT 2, 'Febrero' UNION ALL
            SELECT 3, 'Marzo' UNION ALL
            SELECT 4, 'Abril' UNION ALL
            SELECT 5, 'Mayo' UNION ALL
            SELECT 6, 'Junio' UNION ALL
            SELECT 7, 'Julio' UNION ALL
            SELECT 8, 'Agosto' UNION ALL
            SELECT 9, 'Septiembre' UNION ALL
            SELECT 10, 'Octubre' UNION ALL
            SELECT 11, 'Noviembre' UNION ALL
            SELECT 12, 'Diciembre'
        )

        SELECT
            M.Mes,
            ISNULL(COUNT(C.Id_Cita), 0) AS TotalCitas
        FROM Meses M
        LEFT JOIN Citas C
            ON MONTH(C.Fecha) = M.NumMes
           AND YEAR(C.Fecha) = YEAR(GETDATE())
        GROUP BY M.NumMes, M.Mes
        ORDER BY M.NumMes;

    END TRY
    BEGIN CATCH

        SELECT
            CAST(NULL AS VARCHAR(20)) AS Mes,
            CAST(NULL AS INT) AS TotalCitas
        WHERE 1 = 0;

    END CATCH
END
GO