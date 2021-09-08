<script>
  import { token } from "./../stores.js";
  import { Link } from "svelte-navigator";

  $: isAuthenticated = $token;
</script>

<footer class="pt-3">
  <div class="footer-content p-3 m-0">
    <section class="">
      <div class="container text-center text-md-start mt-5">
        <div class="row mt-3">
          <div class="col-md-3 col-lg-4 col-xl-3 mx-auto mb-4">
            <h6 class="text-uppercase fw-bold mb-4">
              <img src="/images/logo.png" class="logo" alt="logo" />
            </h6>
            <p>
              Here you can use rows and columns to organize your footer content.
              Lorem ipsum dolor sit amet, consectetur adipisicing elit.
            </p>
          </div>
          <div class="col-md-3 col-lg-2 col-xl-2 mx-auto mb-4">
            <h6 class="text-uppercase fw-bold mb-4">Przydatne linki</h6>
            <p>
              <Link to="/" class="text-reset">Strona główna</Link>
            </p>
            <p>
              <Link to="/search" class="text-reset">Wyszukiwanie</Link>
            </p>
            <p>
              <Link to="/about" class="text-reset">O nas</Link>
            </p>
          </div>
          <div class="col-md-3 col-lg-2 col-xl-2 mx-auto mb-4">
            <h6 class="text-uppercase fw-bold mb-4">Przydatne linki</h6>
            <p>
              <Link to="/manage" class="text-reset">Zarządzaj</Link>
            </p>
            {#if isAuthenticated}
              <p>
                <Link to="/logout" class="text-reset">Wyloguj</Link>
              </p>
            {:else}
              <p>
                <Link to="/login" class="text-reset">Zaloguj</Link>
              </p>
            {/if}
          </div>
        </div>
      </div>
    </section>
    <div class="text-center p-2" style="background-color: rgba(0, 0, 0, 0.05);">
      © 2021 Copyright
    </div>
  </div>
</footer>

<style lang="scss">
  @import "../global.scss";

  footer {
    background-color: $green2;
  }
  .footer-content {
    background-color: $green1;
    color: white;
  }

  .logo {
    max-height: 60px;
  }
</style>
