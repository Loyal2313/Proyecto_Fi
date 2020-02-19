<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>UhhYeah</title>

    <!--CSS-->
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/css/materialize.min.css">
    <link rel="stylesheet" type="text/css" href="<?php echo $_SESSION['public'] ?>css/app.css">

</head>

<body>
<nav>
    <div class="nav-wrapper">
        <!--Logo-->
        <a href="<?php echo $_SESSION['home'] ?>" class="brand-logo" title="Inicio">
            <img src="<?php echo $_SESSION['public'] ?>img/skull-blanco.png" alt="Logo Juego">
        </a>

        <!--Botón menú móviles-->
        <a href="#" data-target="mobile-demo" class="sidenav-trigger"><i class="material-icons">menu</i></a>

        <!--Menú de navegación-->
        <ul id="nav-mobile" class="right hide-on-med-and-down">
            <li>
                <a href="<?php echo $_SESSION['home'] ?>" title="Inicio">Inicio</a>
            </li>
            <li>
                <a href="<?php echo $_SESSION['home'] ?>acerca-de" title="Acerca de">Acerca de</a>
            </li>
            <li>
                <?php
                if (isset($_SESSION['usuario'])){
                    echo "<a href=".$_SESSION['home']."partidas title='Partidas'>Partidas</a>";
                }
                ?>
            </li>
            <li>
                <?php
                if (isset($_SESSION['usuario'])){
                    echo "<a href=".$_SESSION['home']."salir title='Salir'>Salir</a>";
                }
                else {
                    echo "<a href=".$_SESSION['home']."login title='Login'>Login/ Registro</a>";
                }
                ?>

            </li>
            <li>
                <a href="<?php echo $_SESSION['home'] ?>admin" title="Panel de administración"
                   target="_blank" class="grey-text">
                    Admin
                </a>
            </li>
        </ul>

    </div>
</nav>

<!--Menú de navegación móvil-->
<ul class="sidenav" id="mobile-demo">
    <li>
        <a href="<?php echo $_SESSION['home'] ?>" title="Inicio">Inicio</a>
    </li>
    <li>
        <a href="<?php echo $_SESSION['home'] ?>acerca-de" title="Acerca de">Acerca de</a>
    </li>
    <li>
        <?php
        if (isset($_SESSION['usuario'])){
            echo "<a href=".$_SESSION['home']."partidas title='Partidas'>Partidas</a>";
        }
        ?>
    </li>
    <li>
        <?php
        if (isset($_SESSION['usuario'])){
            echo "<a href=".$_SESSION['home']."salir title='Salir'>Salir</a>";
        }
        else {
            echo "<a href=".$_SESSION['home']."login title='Login'>Login/ Registro</a>";
        }
        ?>

    </li>
    <li>
        <a href="<?php echo $_SESSION['home'] ?>admin" title="Panel de administración"
           target="_blank" class="grey-text">
            Admin
        </a>
    </li>
</ul>

<main>

    <header>
        <h1 style="text-decoration: underline; font-weight: bold">Juego Square-Man</h1>
    </header>

    <section class="container-fluid">
