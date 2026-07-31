\# 04\_DatosPrueba



En esta carpeta se almacenan los scripts con datos de prueba para facilitar el desarrollo y las pruebas del sistema.



Estos scripts deben ejecutarse después de crear la base de datos, las tablas y los procedimientos almacenados.



\¿Qué es \`LoteDatos.sql\`?



Es el script que llena la base de datos con un lote de datos de prueba realistas, 
para que cualquier compañero pueda probar el sistema (listados, filtros, reportes, etc.) 
sin tener que estar registrando información manualmente desde la aplicación.



A diferencia de un \`INSERT\` directo, este script inserta TODOS los datos llamando a los propios \`SP\_INSERTA\_X\` 
de cada tabla (los que están en \`03\_Procedimientos\`). Esto tiene dos ventajas:



\- Sirve como prueba de que los procedimientos de inserción funcionan correctamente de principio a fin 
(incluyendo el registro automático en \`Auditoria\`).

\- Los datos quedan validados por las mismas reglas de negocio que va a usar la aplicación real (duplicados, 
llaves foráneas, etc.), en vez de insertarse "a la fuerza" sin pasar por esas validaciones.



Qué incluye el lote de datos:



\- Roles, Tipos de Identificación, Especialidades, Especies y Razas (catálogos base)

\- Propietarios y Veterinarios

\- Usuarios (incluyendo un usuario \`admin\` semilla, necesario para poder ejecutar el resto de los procedimientos, ya que todos exigen un \`@IdUsuarioGlobal\` existente para el control de auditoría)

\- Mascotas, ligadas a Propietarios y Razas

\- Citas, ligadas a Mascotas y Veterinarios

\- Consultas, generadas únicamente para las citas marcadas como \`Atendida\`



Al final del script hay una consulta de verificación que muestra cuántas filas se insertaron por tabla, 
para confirmar que todo se cargó correctamente.



Requisito: la base de datos debe estar recién creada (tablas vacías) antes de correr este script, 
ya que las relaciones entre tablas se arman asumiendo que los \`IDENTITY\` empiezan desde 1.