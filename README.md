# tl2-tp1-2023-franciscojvicente
tl2-tp1-2023-franciscojvicente created by GitHub Classroom

¿Cuál de estas relaciones considera que se realiza por composición y cuál por
agregación?
Por agregacion: Cadete-Pedidos
Por composición: Pedidos-Cliente, Cadete-Cadeteria

¿Qué métodos considera que debería tener la clase Cadetería y la clase Cadete?

La clase cadeteria deberia tener los metodos:
    AsignarPedido();
    AgregarCadete();
    EliminarCadete();
La clase cadete deberia tener los metodos:
    TomarPedido();
    AbandonarPedido();

Teniendo en cuenta los principios de abstracción y ocultamiento, que atributos,
propiedades y métodos deberían ser públicos y cuáles privados?

Deberian ser publicos:
En un principio todos los métodos deberían

Deberian ser privados:

¿Cómo diseñaría los constructores de cada una de las clases?

Para Cliente y cadetería crearía un constructor para asignar los datos
Para Pedidos y Cadete crearía un constructor que reciba datos menos en Id y Nro que haría que sea autoincremental de modo tal que nunca se repitan
