<?php

$db = new mysqli('localhost', 'root', 'Uhhyeah123*', 'unity');
$db->set_charset('utf8');

$usuario = filter_input(INPUT_POST, "nombre", FILTER_SANITIZE_STRING);
$contrasena = filter_input(INPUT_POST, "clave", FILTER_SANITIZE_STRING);
$puntos = filter_input(INPUT_POST, "puntos", FILTER_SANITIZE_STRING);


// Comprobamos que el usuario existe
$rowset = $db->query("SELECT id FROM usuarios WHERE nombre='$usuario' AND activo=1 LIMIT 1");
$row = $rowset->fetch_array(MYSQLI_BOTH);
$idUsuario = 0;
if ($row != null){ //Recorro el resultado
    $idUsuario = $row[0];
    $row = $rowset->fetch_array(MYSQLI_BOTH);
}
else {
    echo "USUARIO NO EXISTE";
    echo "<h3>USUARIO NO EXISTE</h3>";
}
$rowset->free(); //Libero de la memoria
echo "";


// Comprobamos que la contraseña esté bien
if ($idUsuario != 0){
    $resultado = $db->query("SELECT clave FROM usuarios WHERE id='$idUsuario'");
    $res = $resultado->fetch_array(MYSQLI_BOTH);
    while ($res != null){ //Recorro el resultado
        $clave = $res[0];
        if (password_verify($contrasena, $clave)){
            echo "TODO CORRECTO";
            echo "<h3>TODO CORRECTO</h3>";
            $db-> query('INSERT INTO partidas VALUES ('.$idUsuario.', '.$puntos.', sysdate(), 0)');
        }
        else {
            echo "CONTRASEÑA INCORRECTA";
            echo "<h3>CONTRASEÑA INCORRECTA</h3>";
        }
        $res = $resultado->fetch_array(MYSQLI_BOTH);
    }
    $resultado->free(); //Libero de la memoria
    echo "";
}








