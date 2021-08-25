<script>
  import { Link } from "svelte-navigator";
</script>

<div class="niebieskie">
  <div class="container">
    <div class="banner">
      <h1 class="main-headline">Witam Pozdrawiam</h1>
      <p class="description">
        Witam na mojej pierwszej stronce internetowej. Jest ona bardzo ładna,
        responsywana i w ogóle super. Napracowałam się i jestem z niej dumna.
      </p>

      <div class="guziczki">
        <div class="guziczek">
          <Link to="/search" class="text-reset">Wyszukaj</Link>
        </div>
        <div class="guziczek">
          <Link to="/manage" class="text-reset">Zarządzaj</Link>
        </div>
      </div>
    </div>
  </div>
</div>

<style>
  .niebieskie {
    background-color: royalblue;
    height: 350px;
    margin-bottom: 20px;
    margin-top: 20px;
    padding: 20px, 0px, 20px, 0px;
  }
  .main-headline {
    text-align: center;
    color: whitesmoke;
    font-size: 48px;
    padding-top: 50px;
  }

  .description {
    text-align: center;
    color: whitesmoke;
    font-size: 18px;
    padding-top: 25px;
    padding-bottom: 25px;
  }
  .guziczek {
    border: 2px solid whitesmoke;
    height: 40px;
    line-height: 40px; /* środkowanie tekstu... */
    box-sizing: content-box; /* ...pionowo */
    width: 120px;
    margin: 10px 5px 15px 5px;
    text-align: center;
    color: whitesmoke;
  }
  .guziczki {
    display: flex;
    justify-content: center;
  }
</style>
