\# 03\_Procedimientos



En esta carpeta se almacenan los procedimientos almacenados del sistema.



Se utilizará la convención definida por el profesor.



Estructura de la carpeta:



\- Existe una subcarpeta por cada tabla del sistema (\`SPs\_Especies\`, \`SPs\_Razas\`, \`SPs\_Propietarios\`, 
\`SPs\_Veterinarios\`, \`SPs\_Mascotas\`, \`SPs\_Citas\`, \`SPs\_Consultas\`, \`SPs\_Usuarios\`, \`SPs\_Especialidades\`, 
\`SPs\_Tipos\_Identificacion\`), y dentro de cada una están sus 5 procedimientos: 

\`SP\_LISTAR\_X\`, \`SP\_FILTRAR\_X\`, \`SP\_INSERTA\_X\`, \`SP\_ACTUALIZA\_X\` y \`SP\_ELIMINA\_X\`.



\- Los procedimientos especiales de \`SP\_INICIAR\_SESION\` y \`SP\_INFO\_USUARIOS\` (login e información de usuario) 
están junto a la carpeta \`SPs\_Usuarios\`.



Ejemplos:



SP\_INSERTA\_MASCOTAS.sql

SP\_ACTUALIZA\_MASCOTAS.sql

SP\_ELIMINA\_MASCOTAS.sql

SP\_LISTAR\_MASCOTAS.sql

SP\_FILTRAR\_MASCOTAS.sql



\¿Para qué sirven estos scripts individuales?



Estos scripts, un procedimiento por archivo, son solo para labores de \*\*mantenimiento\*\* 
(por ejemplo, si hay que corregir la lógica de un solo procedimiento, agregar una validación, 
o depurar un error específico sin tener que tocar el resto del proyecto).



Para una \*\*instalación nueva y rápida\*\* del proyecto (crear todos los procedimientos almacenados de todas 
las tablas de una sola vez), no se usan estos scripts sueltos: se usa un único script consolidado que junta todos 
los procedimientos de esta carpeta (y sus subcarpetas) en el orden correcto. Ese script se le comparte a cualquier 
compañero que necesite instalar el proyecto en su computadora: lo corre una sola vez con F5, después de haber creado 
la base de datos y las tablas, y ya tiene todos los procedimientos almacenados listos.



¿Por qué scripts sueltos Y un script consolidado si hacen básicamente lo mismo?



\- El script \*\*SPs_CreacionScript.sql\*\* existe para que la instalación local del proyecto sea rápida y no dependa 
de correr más de 50 archivos sueltos uno por uno.

\- Los scripts \*\*sueltos por tabla\*\* existen por si en algún momento se necesita hacer mantenimiento sobre un 
procedimiento en particular, sin tener que regenerar ni volver a correr todo el script consolidado.



Esta es la misma lógica que se sigue en las carpetas \*\*01_BaseDeDatos\*\* y \*\*02_Tablas\*\*.



Requisito: este script (sea el consolidado o los sueltos) debe correrse DESPUÉS de haber creado la base de datos y las tablas.