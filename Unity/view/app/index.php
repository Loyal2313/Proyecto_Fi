<?php
if (isset($_SESSION['usuario'])){
    $user = $_SESSION['usuario'];
    if (isset($_SESSION['foto'])){
        $foto = "img/".$_SESSION['foto'];
        $ruta = $_SESSION['public'];
        echo "<img style='width: 8rem' src='$ruta$foto'>";
    }
    echo "<h3><a href='http://18.184.61.233/Unity/public/index.php/editar'>".$user."</a></h3>";
}
else {
    echo "<h3 style='font-weight: normal'>Inicio</h3>";
}

?>

<img style="margin-left: 38%; margin-top: 3%" src="<?php echo $_SESSION['public'] ?>img/megapacman.jpg">





