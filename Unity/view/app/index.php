<?php
if (isset($_SESSION['usuario'])){
    $user = $_SESSION['usuario'];
    if (isset($_SESSION['foto'])){
        $foto = "img/".$_SESSION['foto'];
        $ruta = $_SESSION['public'];
        echo "<img style='width: 8rem' src='$ruta$foto'>";
    }
    echo "<h3><a href='http://18.184.61.233/Unity/public/index.php/editar'><span style='color: white'>Editar</span> ".$user."</a></h3>";
}
else {
    echo "<h3 style='font-weight: normal'>Inicio</h3>";
}

?>

<div style="text-align: center"><img id="centro" src="<?php echo $_SESSION['public'] ?>img/megapacman.jpg"></div>





