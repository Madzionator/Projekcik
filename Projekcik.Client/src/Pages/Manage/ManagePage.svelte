<script>
  import { Link } from "svelte-navigator";

  let logo = "/images/logo.png";
</script>

<head>
  <style>
    body {
      background-color: #eee;
    }
  </style>
</head>

<div class="container prostokat p-3 p-lg-5 mx-auto my-5">
  <img src={logo} alt="logo" class="logo" />

  <hr />
  <div class="napis mb-5">
    <h3>Panel administracyjny</h3>
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
        <i class="fas fa-map-marker-alt ikonka m-2" /><br />Miejsca
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
</div>

<style lang="scss">
  .prostokat {
    background-color: white;
    border: 1px solid black;
    border-radius: 5px;
    text-align: center;
    border-bottom-width: 2px;
    box-shadow: 3px 3px 10px rgba(0, 0, 0, 0.2);
  }

  .logo {
    max-width: 500px;
    width: 100%;
  }

  .ikonka {
    font-size: 2rem;
  }

  .pole {
    margin: 5px;
    padding: 10px;
    width: 150px;
    border-bottom-width: 2px;
    background-color: rgb(217, 180, 146);
    color: white;
    text-shadow: 1px 1px 2px rgba(0, 0, 0, 0.5);
  }

  .pole:hover {
    background-color: rgb(200, 150, 120);
  }
</style>
