<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>Admin</title>

    <!--CSS-->
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/css/materialize.min.css">
    <link rel="stylesheet" type="text/css" href="<?php echo $_SESSION['public'] ?>css/admin.css">

    <!--FUENTES-->
    <link href="https://fonts.googleapis.com/css?family=Tomorrow&display=swap" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css?family=Exo+2&display=swap" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css?family=Source+Code+Pro&display=swap" rel="stylesheet">

</head>

<body>
<nav>
    <div class="nav-wrapper">
        <!--Logo-->
        <a href="<?php echo $_SESSION['home'] ?>admin" class="brand-logo" title="Inicio">
            <img src="<?php echo $_SESSION['public'] ?>img/skull-blanco.png" alt="Logo Juego">
        </a>

        <?php if (isset($_SESSION['usuario'])){ ?>

            <!--Botón menú móviles-->
            <a href="#" data-target="mobile-demo" class="sidenav-trigger"><i class="material-icons">menu</i></a>

            <!--Menú de navegación-->

        <?php } ?>

    </div>
</nav>

<?php if (isset($_SESSION['usuario'])){ ?>

    <!--Menú de navegación móvil-->

<?php } ?>

<!-- Si existen mensajes  -->
<?php if (isset($_SESSION["mensaje"])) { ?>

    <!-- Los muestro ocultos -->
    <input type="hidden" name="tipo-mensaje" value="<?php echo $_SESSION["mensaje"]['tipo'] ?>">
    <input type="hidden" name="texto-mensaje" value="<?php echo $_SESSION["mensaje"]['texto'] ?>">

    <!-- Borro mensajes -->
    <?php unset($_SESSION["mensaje"]) ?>

<?php } ?>

<main>

    <header>
        <h1>¡¡¡Zona Admin!!!</h1>

        <?php if (isset($_SESSION['usuario'])){ ?>

            <h2>
                Usuario: <strong><?php echo $_SESSION['usuario'] ?></strong>
            </h2>
            <h6 style="text-align: center; font-style: italic">Realizar acciones con precaución, ya que tendrán impacto permanente sobre la base de datos</h6>

        <?php } ?>

    </header>

    <section class="container-fluid">
