<?php

function ImprimeArray($array){
    echo "<pre>";
    print_r($array);
    echo "</pre>";
}

$user = $_SESSION['usuario'];
echo "<h3 style='margin-bottom: 5%;'>Partidas de <span style='color: yellow;'>".$user."</span></h3>";

$db = new mysqli('localhost', 'root', 'Uhhyeah123*', 'unity');
$db->set_charset('utf8');




// Saco el id del usuario
$id = 0;
$idUsuario = $db-> query('SELECT id FROM usuarios WHERE nombre = "'.$user.'"');
$idU = $idUsuario->fetch_array(MYSQLI_BOTH);
while ($idU != null){ //Recorro el resultado
    $id = $idU[0];
    $idU = $idUsuario->fetch_array(MYSQLI_BOTH);
}
$idUsuario->free(); //Libero de la memoria
echo "";

if (isset($_POST['fecha'])){
    $db-> query('UPDATE partidas SET borrada = 1 WHERE fecha = "'.$_POST["fecha"].'"');
}


// Busco sus partidas

$partidas = $db-> query('SELECT puntos, fecha FROM partidas WHERE id = '.$id.' AND borrada = 0 ORDER BY puntos DESC');

$part = $partidas->fetch_array(MYSQLI_BOTH);

while ($part != null){ //Recorro el resultado
    echo "<div class='partida'><form action='' method='POST'><span style='margin-right: 2%; font-weight: bold;'>Puntos: </span>".$part[0]."<input name='fecha' readonly value='".$part[1]."'><button type='submit' style='margin-left: 5%; margin-bottom: 5%; margin-top: 2%; color: white;'>Borrar Partida</button></form></div>";
    $part = $partidas->fetch_array(MYSQLI_BOTH);
}



$partidas->free(); //Libero de la memoria
echo "";




