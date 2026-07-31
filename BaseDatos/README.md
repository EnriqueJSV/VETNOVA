\# BaseDatos


Esta carpeta contiene todos los scripts relacionados con la base de datos del proyecto VetNova.



\¿Cómo está organizada esta carpeta?



Está dividida en 5 subcarpetas, cada una con un propósito distinto dentro del ciclo de vida de la base de datos (desde crearla desde cero, hasta probar que todo funcione):



\- \*\*01\_BaseDeDatos\*\* → Creación de la base de datos \`VetNova\`.

\- \*\*02\_Tablas\*\* → Creación de las 12 tablas del sistema.

\- \*\*03\_Procedimientos\*\* → Los procedimientos almacenados (\`SP\_LISTAR\_X\`, \`SP\_FILTRAR\_X\`, 
\`SP\_INSERTA\_X\`, \`SP\_ACTUALIZA\_X\`, \`SP\_ELIMINA\_X\` de cada tabla, más los especiales de login).

\- \*\*04\_DatosPrueba\*\* → El lote de datos de prueba (\`LoteDatos.sql\`) para llenar la base de datos y 
poder probar el sistema con información realista.

\- \*\*05\_Consultas\*\* → Consultas y scripts de apoyo para pruebas y validación (\`SP\_DATA\_TESTING.sql\`), 
que no forman parte del sistema como tal.



\¿Por qué está organizada así?



El número al inicio de cada carpeta (01, 02, 03...) indica el \*\*orden en el que se deben ejecutar 
los scripts\*\* la primera vez que se instala el proyecto, porque cada carpeta depende de que la anterior ya 
se haya corrido (no se pueden crear tablas sin que exista la base de datos, no se pueden crear procedimientos sin 
que existan las tablas, y no se pueden probar los procedimientos sin que existan los datos de prueba). Es la misma 
lógica de dependencias que se usa dentro del código SQL (llaves foráneas), aplicada también al orden de las carpetas.



Dentro de cada carpeta (01, 02 y 03) vas a encontrar dos formas de hacer lo mismo:



\- Un \*\*script consolidado\*\* (todo en un solo archivo), pensado para que cualquier compañero pueda instalar el proyecto 
completo en su computadora en menos de un minuto, sin tener que correr decenas de archivos sueltos uno por uno.

\- \*\*Scripts individuales\*\* (uno por tabla o por procedimiento), pensados únicamente para labores 
de \*\*mantenimiento\*\*: modificar la estructura de una sola tabla, corregir la lógica de un solo procedimiento, etc., 
sin tener que tocar ni volver a generar todo el script consolidado.



Orden recomendado de ejecución (instalación desde cero, usando los scripts consolidados):



1\. 01\_BaseDeDatos (script consolidado: base de datos + tablas)

2\. 03\_Procedimientos (script consolidado: todos los procedimientos almacenados)

3\. 04\_DatosPrueba (\`LoteDatos.sql\`)

4\. 05\_Consultas (\`SP\_DATA\_TESTING.sql\`, opcional, solo para validar que todo funcione)



La carpeta 05\_Consultas contiene únicamente consultas de apoyo para pruebas y desarrollo; no es parte del sistema 
en producción.



Reglas del equipo



\- Cada tabla debe tener su propio archivo SQL.

\- Cada integrante solo modificará los archivos correspondientes a su módulo.

\- Los procedimientos almacenados deberán seguir la convención de nombres establecida por el profesor.

\- Antes de crear un Pull Request, verificar que los scripts se ejecuten correctamente en SQL Server.

\- Si se modifica un script individual (tabla o procedimiento), recordar actualizar también el script consolidado correspondiente, para que ambos se mantengan sincronizados.