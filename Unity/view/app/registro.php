<?php

$db = new mysqli('localhost', 'root', 'Uhhyeah123*', 'unity');
$db->set_charset('utf8');

$letras = '/^[A-Za-z" "áéíóúñÁÉÍÓÚÑ-]{2,20}$/';

$_SESSION["name"] = $_POST["name"];
$_SESSION["pw"] = $_POST["pw"];


?>

<div class="container" id="form">

    <form action="" method="POST"><br><br>
        <div class="col-12">Usuario: <input type="text" name="name" value="<?php echo $_SESSION["name"] ?>"></div>
        <?php

        if (isset($_POST["name"])) {
            $resultado = $db->query('SELECT id FROM usuarios WHERE nombre="'.$_POST["name"].'"');
            if ($_POST["name"] == ""){
                echo '<br><p class="error">Introduzca su nombre de usuario</p>';
                $nameCorrect = false;
            }
            else if (preg_match($letras, $_POST["name"]) == false && $_POST["name"] !== ""){
                echo '<br><p class="error">Solo se permiten caracteres alfabéticos</p>';
                $nameCorrect = false;
            }
            else {
                $exists = false;
                $name = $resultado->fetch_array(MYSQLI_BOTH);
                if ($name == null){ //Recorro el resultado
                    $exists = false;
                    $name = $resultado->fetch_array(MYSQLI_BOTH);
                }
                else {
                    $exists = true;
                    $name = $resultado->fetch_array(MYSQLI_BOTH);
                }
                $resultado->free(); //Libero de la memoria
                echo "";

                if ($exists == true){
                    echo '<br><p class="error">Username already exists</p>';
                }
                else {
                    $nameCorrect = true;
                }
            }
        }

        ?><br>
        <div class="col-12">Contraseña: <input type="password" name="pw" value="<?php echo $_SESSION["pw"] ?>"></div>
        <?php
        if (isset($_POST["pw"])) {
            if ($_POST["pw"] == ""){
                echo '<br><p class="error">Enter your password</p>';
                $pwCorrect = false;
            }
            else {
                $pwCorrect = true;
            }
        }
        ?><br><br><br><br>
        <div class="col-12"><button id="login" type="submit">Registrar</button></div><br>
    </form>
</div>

<?php

if ($nameCorrect == true && $pwCorrect == true){
    $claveNueva = password_hash($_POST["pw"],  PASSWORD_BCRYPT, ['cost'=>12]);
    $result = $db-> query('SELECT MAX(id) FROM usuarios');
    $maxid = $result->fetch_array(MYSQLI_BOTH);
    while ($maxid != null){ //Recorro el resultado
        $newid = $maxid[0]+1;
        $maxid = $result->fetch_array(MYSQLI_BOTH);
    }
    $result->free(); //Libero de la memoria
    echo "";
    $db-> query('INSERT INTO usuarios (id, nombre, clave, fecha_acceso, activo, admin) VALUES ('.$newid.', "'.$_POST["name"].'", "'.$claveNueva.'", sysdate(), 0, 0)');
    header('Location: http://18.184.61.233/Unity/public/index.php/login');
}

?>
