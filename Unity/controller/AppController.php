<?php
namespace App\Controller;

use App\Helper\ViewHelper;
use App\Helper\DbHelper;


class AppController
{
    var $db;
    var $view;

    function __construct()
    {
        //Conexión a la BBDD
        $dbHelper = new DbHelper();
        $this->db = $dbHelper->db;

        //Instancio el ViewHelper
        $viewHelper = new ViewHelper();
        $this->view = $viewHelper;
    }

    public function index()
    {
        //Llamo a la vista
        $this->view->vista("app", "index");
    }

    public function acercade()
    {
        //Llamo a la vista
        $this->view->vista("app", "acerca-de");

    }

    public function partidas()
    {
        //Llamo a la vista
        $this->view->vista("app", "partidas");

    }

    public function login()
    {
        //Llamo a la vista
        $this->view->vista("app", "login");

    }

    public function registro()
    {
        //Llamo a la vista
        $this->view->vista("app", "registro");

    }

    public function editar()
    {
        //Llamo a la vista
        $this->view->vista("app", "editar");

    }

    public function unity()
    {
        //Llamo a la vista
        $this->view->vista("app", "unity");

    }

    public function salir()
    {
        // Logout
        unset($_SESSION["usuario"]);

        //Llamo a la vista
        $this->view->vista("app", "index");

    }


}
