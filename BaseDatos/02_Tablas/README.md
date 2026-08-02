\# 02\_Tablas



En esta carpeta se almacenan los scripts de creación de las tablas del sistema.



Cada tabla tiene su propio archivo SQL, para que cada integrante pueda modificar únicamente la 
tabla que le corresponde sin afectar las demás.



Ejemplo:



Tipos_Identificacion.sql

Especialidades.sql

Especies.sql

Razas.sql

Propietarios.sql

Usuarios.sql

Veterinarios.sql

Mascotas.sql

Auditoria.sql

Citas.sql

Consultas.sql

Roles.sql



\¿Para qué sirven estos scripts individuales?



Estos scripts, tabla por tabla, son solo para labores de \*\*mantenimiento\*\* (por ejemplo, si hay que modificar 
la estructura de una sola tabla, agregar una columna, corregir una llave foránea, etc. sin tener que tocar el resto del proyecto).



Para una \*\*instalación nueva y rápida\*\* del proyecto (crear la base de datos con todas sus tablas de una sola vez), 
no se usan estos scripts sueltos: se usa el script combinado que está en la carpeta \*\*0\_BaseDeDatos\*\* 
(BD&Tablas_CreacionScript.sql), el cual ya incluye la creación de todas estas tablas en el orden correcto según sus dependencias.



Orden de dependencias (por si se necesitan correr manualmente, uno por uno):



1\. Roles

2\. Tipos\_Identificacion

3\. Especialidades

4\. Especies

5\. Razas

6\. Propietarios

7\. Usuarios

8\. Veterinarios

9\. Mascotas

10\. Auditoria

11\. Citas

12\. Consultas