\# 05\_Consultas



En esta carpeta se almacenan consultas SQL utilizadas para pruebas, validaciones y apoyo durante el desarrollo.



Estas consultas no forman parte del sistema ni deben utilizarse como procedimientos almacenados.



\¿Qué es \`SP\_DATA\_TESTING.sql\`?



Es el script que prueba, uno por uno, todos los procedimientos almacenados que NO son de inserción: 
\`SP\_LISTAR\_X\`, \`SP\_FILTRAR\_X\`, \`SP\_ACTUALIZA\_X\` y \`SP\_ELIMINA\_X\` de cada tabla (los \`SP\_INSERTA\_X\` 
ya se prueban aparte, en \`LoteDatos.sql\`).



¿Por qué existe este script?



Para poder validar que cada procedimiento funciona correctamente sin tener que probarlo manualmente desde la aplicación 
en Visual Studio cada vez que se modifica algo. Sirve como una prueba automática de regresión: si algún procedimiento se 
rompe después de un cambio, este script lo va a mostrar con un error o con un resultado inesperado.



Cómo funciona (el mismo patrón para cada tabla):



1\. Se crea un registro de PRUEBA propio (con el prefijo \`TEST\_\`), para no depender del \`SP\_INSERTA\_X\` 
ni afectar los datos reales de \`LoteDatos.sql\`.

2\. Se llama \`SP\_LISTAR\_X\` (solo para confirmar que no falla).

3\. Se llama \`SP\_FILTRAR\_X\` buscando ese registro de prueba.

4\. Se llama \`SP\_ACTUALIZA\_X\` sobre el registro de prueba, y se muestra con un \`SELECT\` cómo quedó después del cambio.

5\. Se llama \`SP\_ELIMINA\_X\` sobre el registro de prueba, y se confirma con un \`SELECT COUNT(\*)\` que ya no existe.



Caso especial \- Usuarios: este script también prueba \`SP\_INFO\_USUARIOS\` y \`SP\_INICIAR\_SESION\` 
(con contraseña correcta e incorrecta). Además, deja documentado con comentarios por qué \`SP\_ELIMINA\_USUARIOS\` 
NO borra a un usuario que ya tenga historial en \`Auditoria\` (por ejemplo, que ya haya iniciado sesión una vez): 
esto es una regla de negocio decidida por el equipo (en vez de eliminar, un usuario con historial se debe inactivar 
cambiando su \`Estado\` a \`I\` con \`SP\_ACTUALIZA\_USUARIOS\`), no un error del procedimiento.



Requisito: haber corrido primero los scripts de \`01\_BaseDeDatos\`, \`02\_Tablas\` y \`03\_Procedimientos\`.