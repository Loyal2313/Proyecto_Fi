<?php

$db = new mysqli('localhost', 'root', 'Uhhyeah123*', 'unity');
$db->set_charset('utf8');

$letras = '/^[A-Za-z" "áéíóúñÁÉÍÓÚÑ-]{2,20}$/';

$idUsuario = 0;

function ImprimeArray($array){
    echo "<pre>";
    print_r($array);
    echo "</pre>";
}

?>

<div class="container">

    <form action="" method="POST"><br><br>
        <div class="col-12">Usuario: <input type="text" name="name" value=""></div>
        <?php

        $resultado = $db->query('SELECT id, nombre, clave FROM usuarios');


        if (isset($_POST["name"])) {
            if ($_POST["name"] == ""){
                echo '<br><p class="error">Introduzca su nombre de usuario</p>';
                $nameCorrect = false;
            }
            else if (preg_match($letras, $_POST["name"]) == false && $_POST["name"] !== ""){
                echo '<br><p class="error">Solo se permiten caracteres alfabéticos y numéricos</p>';
                $nameCorrect = false;
            }
            else {
                $users = $resultado->fetch_array(MYSQLI_BOTH); //O también $resultado->fetch_array()
                $is = false;
                while ($users != null){ //Recorro el resultado
                    $string = $users['nombre']." ";
                    if (strpos($string, $_POST["name"]) !== false){
                        $nameCorrect = true;
                        $is = true;
                    }
                    $users = $resultado->fetch_array(MYSQLI_BOTH);
                }
                $resultado->free(); //Libero de la memoria
                echo "";
                if ($is == false){
                    echo '<br><p class="error">Usuario no existe</p>';
                }
            }

        }
        ?><br>
        <div class="col-12">Contraseña: <input type="password" name="pw" value="<?php echo $_SESSION["pw"] ?>"></div>
        <?php
        if (isset($_POST["pw"])) {
            $campo_clave = filter_input(INPUT_POST, "pw", FILTER_SANITIZE_STRING);
            if ($_POST["pw"] == ""){
                echo '<br><p class="error">Introduzca su contraseña</p>';
                $pwCorrect = false;
            }
            else {
                $resultado = $db->query('SELECT clave FROM usuarios WHERE nombre="'.$_POST["name"].'"');
                $pw = $resultado->fetch_array(MYSQLI_BOTH); //O también $resultado->fetch_array()
                while ($pw != null){ //Recorro el resultado
                    $p = $pw[0];
                    $pw = $resultado->fetch_array(MYSQLI_BOTH);
                }
                $resultado->free(); //Libero de la memoria
                echo "";
                if (password_verify($campo_clave,$p)){
                    $pwCorrect = true;
                }
                else {
                    echo '<br><p class="error">Contraseña o usuario incorrecto</p>';
                }
            }
        }
        ?><br><br><br>

        <div class="col-12"><button id="login" type="submit">Login</button></div><br>
        <div class="col-12"><a id="register" href="http://18.184.61.233/Unity/public/index.php/registro">Registro</a></div><br>
    </form>
    </div>

<?php




if ($nameCorrect == true && $pwCorrect == true){
    $_SESSION["usuario"] = $_POST["name"];
    $result = $db-> query('SELECT id FROM usuarios WHERE nombre = "'.$_SESSION["usuario"].'"');
    $id = $result->fetch_array(MYSQLI_BOTH);
    while ($id != null){ //Recorro el resultado
        $idUsuario = $id[0];
        $id = $result->fetch_array(MYSQLI_BOTH);
    }
    $result->free(); //Libero de la memoria
    echo "";


    $query = $db->query('SELECT activo, imagen FROM usuarios WHERE id = '.$idUsuario);
    $activo = $query->fetch_array(MYSQLI_BOTH);
    while ($activo != null) { //Recorro el resultado
        $activoUsuario = $activo[0];
        if ($activoUsuario == 1) {
            $_SESSION["foto"] = $activo[1];
            $db-> query('UPDATE usuarios SET fecha_acceso = sysdate() WHERE id = '.$idUsuario.' ');
            header('Location: http://18.184.61.233/Unity/public/index.php/');
        } else {
            unset($_SESSION["usuario"]);
            echo '<br><p style="margin-left: 15%;" class="error">Usuario no está activo</p>';
        }
        $activo = $query->fetch_array(MYSQLI_BOTH);
    }
    $query->free(); //Libero de la memoria
    echo "";
}

?>