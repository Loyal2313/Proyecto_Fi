<h3>Editar Usuario</h3>

<?php

function ImprimeArray($array){
    echo "<pre>";
    print_r($array);
    echo "</pre>";
}

$db = new mysqli('localhost', 'root', 'Uhhyeah123*', 'unity');
$db->set_charset('utf8');

$letras = '/^[A-Za-z" "áéíóúñÁÉÍÓÚÑ-]{2,20}$/';

$nomInicial = $_SESSION["usuario"];


$idUsuario = $db-> query('SELECT id FROM usuarios WHERE nombre = "'.$nomInicial.'"');
$idU = $idUsuario->fetch_array(MYSQLI_BOTH);
while ($idU != null){ //Recorro el resultado
    $id = $idU[0];
    $idU = $idUsuario->fetch_array(MYSQLI_BOTH);
}
$idUsuario->free(); //Libero de la memoria
echo "";

?>

<div class="container" id="form">

    <form action="" method="POST" enctype='multipart/form-data'><br><br>
        <div class="col-12">Nuevo Nombre de Usuario: <input type="text" name="name" value=""></div>
        <?php

        if (isset($_POST["name"])) {
            if ($_POST["name"] == ""){
                echo '<br><p class="error">Introduzca su nombre</p>';
                $nameCorrect = false;
            }
            else if (preg_match($letras, $_POST["name"]) == false && $_POST["name"] !== ""){
                echo '<br><p class="error">Solo se admiten caracteres alfabéticos</p>';
                $nameCorrect = false;
            }
            else {
                $nameCorrect = true;
            }
        }

        ?><br>
        <div class="col-12">Nueva Contraseña: <input type="password" name="pw" value="<?php echo $_POST["pw"] ?>"></div>
        <?php
        if (isset($_POST["pw"])) {
            if ($_POST["pw"] == ""){
                echo '<br><p class="error">Introduzca su contraseña</p>';
                $pwCorrect = false;
            }
            else {
                $pwCorrect = true;
            }
        }
        ?><br>
        <div class="col-12">Nueva Foto: <br><br><input type="file" name="foto" id="foto" value="<?php echo $_POST["foto"] ?>"></div>
        <br><br><br>
        <div class="col-12"><button id="login" type="submit">Guardar</button></div><br>
    </form>
</div>

<?php

if ($nameCorrect == true && $pwCorrect == true){
    $claveNueva = password_hash($_POST["pw"],  PASSWORD_BCRYPT, ['cost'=>12]);


    $nom = $_FILES['foto']['name'];
    $destino = '/var/www/html/Unity/public/img/'.$nom;
    $des_temp = $_FILES['foto']['tmp_name'];
    move_uploaded_file($des_temp, $destino);


    $_SESSION["usuario"] = $_POST["name"];
    $_SESSION["foto"] = $nom;
    $db-> query('UPDATE usuarios SET nombre="'.$_SESSION["usuario"].'", clave="'.$claveNueva.'", imagen = "'.$nom.'" WHERE id="'.$id.'"');
    header('Location: http://18.184.61.233/Unity/public/index.php/');
}



?>