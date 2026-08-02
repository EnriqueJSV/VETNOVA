\# 01_BaseDeDatos


En esta carpeta se almacenan los scripts para la creación de la base de datos.



Aquí vas a encontrar dos scripts distintos, con propósitos diferentes:


01_CrearBaseDatos.sql → Crea ÚNICAMENTE la base de datos \`VetNova\` (el \`CREATE DATABASE\`). No crea tablas 
ni nada más. Se usa solo para labores de mantenimiento, por ejemplo si en algún momento hay que recrear la base de datos desde 
cero sin tocar las tablas todavía.


BD&Tablas_CreacionScript.sql → Crea la base de datos Y todas sus tablas en un solo script, en el orden correcto 
según sus dependencias (llaves foráneas). Este es el que se le comparte a cualquier compañero que necesite instalar 
el proyecto en su computadora rápidamente: lo corre una sola vez con F5 y ya tiene la base de datos lista con su 
estructura completa, en menos de un minuto.


¿Por qué dos scripts si hacen básicamente lo mismo?



\- El script \*\*combinado\*\* (base de datos + tablas) existe para que la instalación local del proyecto sea rápida 
y no dependa de correr varios archivos sueltos.

\- El script que \*\*solo crea la base de datos\*\* existe por si en algún momento se necesita hacer mantenimiento 
(por ejemplo, recrear la base de datos vacía sin afectar la carpeta de tablas, o depurar un problema paso a paso).



Esta misma lógica aplica también a la carpeta \*\*02\_Tablas\*\*: ahí los scripts individuales por tabla son 
solo para mantenimiento, mientras que la creación completa de tablas para una instalación nueva se hace a través 
del script combinado de esta carpeta.



Orden de ejecución (si se usan los scripts separados en vez del combinado):



1\. 01_CrearBaseDatos.sql

2\. Los scripts de la carpeta 02_Tablas