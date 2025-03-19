## En Backend
en appsettings.json poner el connection string correspondiente
```sh
"ConnectionStrings": {
   "SqlConnection": ""
 },
```
En: herramientas/Administrador de paquetes NuGet/Consola de administrador de paquetes realizar la migration correspondiente
```sh
add-migration creacionTabla 
update-database
```

en Program setear la url correspondiente en el Soporte para CORS:
```sh
// Soporte para CORS
// Se pueden habilitar: 1-Un dominio, 2-multiples dominios, 3-cualquier dominio (Tener en cuenta Seguridad)
// Usamos de ejemplo dominio: http://localhost:5173, se debe cambiar por el correcto
// se usa (*) para todos los dominios.
builder.Services.AddCors(p => p.AddPolicy("PolicyCors", build =>
{
    build.WithOrigins("http://localhost:5173").AllowAnyMethod().AllowAnyHeader();
}));
```

## En Frontend:
ir a la carpeta correspondiente dentro de FrontEnd y ejecutar los comandos correspondientes para instalar los paquetes de Node y correr el proyecto:
```sh
cd suris-code-test-front
npm install
npm run dev
```

en SurisApi.ts setear la url correspondiente al backend:
```sh
export const API_URL = 'https://localhost:7250/api'
```

### Este test lo realice despues de mi horario laboral al volver a casa de la oficina, al contar con poco tiempo priorice la estructura de los proyectos de Backend y Frontend dejando la estetica a la imaginacion. Por supuesto se podria mejorar en muchos aspectos, como hacer un formulario mas lindo con validaciones sando Formik y Yup o alguna navegacion, etc, etc. Que tengan un buen día :smile: 
