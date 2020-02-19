<?php

function ImprimeArray($array){
    echo "<pre>";
    print_r($array);
    echo "</pre>";
}

echo "<h3>Usuarios Activos</h3>";

$db = new mysqli('localhost', 'root', 'Uhhyeah123*', 'unity');
$db->set_charset('utf8');

// Borro Usuario
if (isset($_POST['borrar'])){
    $db-> query('DELETE FROM usuarios WHERE id = '.$_POST["borrar"].' ');
    $db-> query('DELETE FROM partidas WHERE id = '.$_POST["borrar"].' ');
}

// Activo Usuario
if (isset($_POST['activar'])){
    $db-> query('UPDATE usuarios SET activo = 1 WHERE id = '.$_POST["activar"].' ');
}

// Imprimo ACTIVOS

$resultado = $db-> query('SELECT * FROM usuarios WHERE activo = 1 AND admin = 0');
$usuario = $resultado->fetch_array(MYSQLI_BOTH);
while ($usuario != null){ //Recorro el resultado
    echo "<p><form action='' style='border: solid 2px black; padding: 3%' method='POST'><span style='font-weight: bold'>Usuario:</span> "
        .$usuario[1]." <input name='borrar' readonly value='".$usuario[0]."'><span style='font-weight: bold'>Última conexión: </span>"
        .$usuario[3]."<br><br><button type='submit' style='margin-left: 5%;'>Borrar Usuario</button></form></p>";
    $usuario = $resultado->fetch_array(MYSQLI_BOTH);
}
$resultado->free(); //Libero de la memoria
echo "";


// Imprimo INACTIVOS

echo "<h3>Usuarios Inactivos</h3>";

$resultado = $db-> query('SELECT * FROM usuarios WHERE activo = 0 AND admin = 0');
$usuario = $resultado->fetch_array(MYSQLI_BOTH);
while ($usuario != null){ //Recorro el resultado
    echo "<p><form action='' style='border: solid 2px black; padding: 3%' method='POST'><span style='font-weight: bold'>Usuario:</span> "
        .$usuario[1]." <input name='activar' readonly value='".$usuario[0]."'><span style='font-weight: bold'>Última conexión: </span>"
        .$usuario[3]."<br><br><button type='submit' style='margin-left: 5%;'>Activar Usuario</button></form></p>";
    $usuario = $resultado->fetch_array(MYSQLI_BOTH);
}
$resultado->free(); //Libero de la memoria
echo "";



