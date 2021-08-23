<script>
  import { Link } from "svelte-navigator";

  let logo = "./images/logo.png";
</script>

<head>
  <style>
    body {
      background-color: #eee;
    }
  </style>
</head>

<body>
  <div class="container prostokat">
    <img src={logo} alt="logo" width="60%" />
    <div class="napis">
      <p>Panel administracyjny</p>
    </div>
    <div>
      <Link to="/manage/jobs">
        <div class="btn pole btn-outline-secondary">
          <i class="fas fa-briefcase ikonka m-2" /><br />Oferty
        </div>
      </Link>

      <Link to="/manage/candidates">
        <div class="btn pole btn-outline-secondary">
          <i class="fas fa-user ikonka m-2" /><br />Kandydaci
        </div>
      </Link>

      <Link to="/manage/locations">
        <div class="btn pole btn-outline-secondary">
          <i class="fas fa-location-arrow ikonka m-2" /><br />Miejsca
        </div>
      </Link>

      <Link to="/manage/keywords">
        <div class="btn pole btn-outline-secondary">
          <i class="fas fa-chart-bar ikonka m-2" /><br /> Umiejętności
        </div>
      </Link>

      <Link to="/manage/search">
        <div class="btn pole btn-outline-secondary">
          <i class="fas fa-search ikonka m-2" /> <br />Wyszukiwanie
        </div>
      </Link>
    </div>
  </div></body
>

<style>
  .prostokat {
    padding: 50px;
    background-color: white;
    border: 1px solid black;
    border-radius: 5px;
    margin: auto;
    width: 80%;
    text-align: center;
  }

  .ikonka {
    font-size: 2rem;
  }
  .pole {
    padding: 10px;
    width: 150px;
    border-bottom-width: 2px;
    background-color: rgb(217, 180, 146);
    color: white;
  }
</style>
