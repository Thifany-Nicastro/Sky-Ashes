<!doctype html>
<html lang="en">

<head>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">

    <!-- Font Awesome -->
    <link href="https://use.fontawesome.com/releases/v5.0.4/css/all.css" rel="stylesheet">

    <!-- Custom styles for this template -->
    <link href="css/navbar.css" rel="stylesheet">
    
    <link rel="shortcut icon" href="img/star.ico" />

    <title>Equipe</title>
</head>

<body>
    <?php
    include_once("header.php")
    ?>

    <main role="main" class="container mt-n3 text-center" id="main">
        <div class="row justify-content-md-center p-5 mt-0">

            <?php
                $str = file_get_contents('equipe.json');
                $json = json_decode($str, true);

                foreach ($json["equipe"]["membros"] as $valor) 
                {
            ?>
                    <div class="col-lg-4 col-md-6 col-sm-12 col-12 my-3">
                        <div class="card card-flip">
                            <div class="card-front">
                                <img src="<?php echo $valor["avatar"]; ?>" class="card-img-top p-3" alt="...">
                                <div class="card-body">
                                    <h3 class="card-title"><?php echo $valor["nome"]; ?></h3>
                                </div>
                            </div>
                            <div class="card-back justify-content-center d-flex align-items-center">
                                <div class="card-body">
                                    <h3 class="card-title"><?php echo $valor["nome"] . " " . $valor["sobrenome"]; ?></h3>
                                    <p class="card-text">Suprise this one has more more more more content on the back!</p>
                                    <a href="https://github.com/<?php echo $valor["github"]; ?>" class="git"><i class="fab fa-github fa-4x"></i></a>
                                </div>
                            </div>
                        </div>
                    </div>
            <?php
                }
            ?>
        </div>
    </main>

    <footer>

    </footer>
    </div>

    <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.4.1.js" integrity="sha256-WpOohJOqMqqyKL9FccASB9O0KwACQJpFTUBLTYOVvVU=" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>

    <script>

    </script>
</body>

</html>
