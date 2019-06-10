<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IniciarSesion.aspx.cs" Inherits="Pediatric_System.IniciarSesion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <title>Inicio de Sesión</title>

    <!--===============================================================================================-->
    <link rel="icon" type="image/png" href="images/icons/favicon.ico" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/bootstrap/css/bootstrap.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.7.0/css/font-awesome.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="fonts/Linearicons-Free-v1.0.0/icon-font.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/animate/animate.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/css-hamburgers/hamburgers.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/animsition/css/animsition.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/select2/select2.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/daterangepicker/daterangepicker.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="css/util.css">
    <link rel="stylesheet" type="text/css" href="css/main.css">
    <!--===============================================================================================-->



</head>
<body style="background-color: #666666;">

    <div class="limiter">
        <div class="container-login100">
            <div class="wrap-login100">
                <form class="login100-form validate-form">
                    <span class="login100-form-title p-b-43">Iniciar Sesión
                    </span>


                    <div class="wrap-input100 validate-input" data-validate="Se requiere un correo electrónico válido">
                        <input class="input100" type="text" name="email" />
                        <span class="focus-input100"></span>
                        <span class="label-input100">Correo Electrónico</span>
                    </div>


                    <div class="wrap-input100 validate-input" data-validate="La contraseña es requerida">
                        <input class="input100" type="password" name="pass" />
                        <span class="focus-input100"></span>
                        <span class="label-input100">Contraseña</span>
                    </div>

                    <div class="flex-sb-m w-full p-t-3 p-b-32">

                        <div>
                            <a href="#" class="txt1">Olvidó su contraseña?
                            </a>
                        </div>
                    </div>


                    <div class="container-login100-form-btn">
                        <button class="login100-form-btn">
                            Ingresar
                        </button>
                    </div>
                </form>

                <div class="login100-more" style="background-image: url('images/bg-01.jpg');">
                </div>
            </div>
        </div>
    </div>


   <%-- <div id="footer">
        <div class="footer-copyright text-center py-3">
            <a href="http://www.freepik.com">Imagen diseñada por jcomp / Freepik</a>
        </div>
    </div>--%>


    <!--===============================================================================================-->
    <script src="vendor/jquery/jquery-3.2.1.min.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/animsition/js/animsition.min.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/bootstrap/js/popper.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.min.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/select2/select2.min.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/daterangepicker/moment.min.js"></script>
    <script src="vendor/daterangepicker/daterangepicker.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/countdowntime/countdowntime.js"></script>
    <!--===============================================================================================-->
    <script src="js/main.js"></script>

</body>



</html>
