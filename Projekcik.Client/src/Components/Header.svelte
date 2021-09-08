<script>
  import { Link } from "svelte-navigator";
  import { token } from "../stores";

  $: isAuthenticated = $token;
</script>

<nav class="navbar navbar-expand-lg navbar-light bg-light">
  <div class="container">
    <Link class="navbar-brand py-0" to="/">
      <img class="logo" src="/images/logo.png" alt="logo" />
    </Link>
    <button
      class="navbar-toggler"
      type="button"
      data-bs-toggle="collapse"
      data-bs-target="#navbarNav"
      aria-controls="navbarNav"
      aria-expanded="false"
      aria-label="Toggle navigation"
    >
      <span class="navbar-toggler-icon" />
    </button>
    <div class="collapse navbar-collapse" id="navbarNav">
      <ul class="navbar-nav me-auto mb-2 mb-lg-0">
        <li class="nav-item">
          <Link class="nav-link" to="/">Home</Link>
        </li>
        <li class="nav-item">
          <Link class="nav-link" to="/search">Wyszukaj</Link>
        </li>
      </ul>
      <form class="d-flex">
        {#if isAuthenticated}
          <Link to="/manage" class="btn btn-outline-success mx-3"
            >Zarządzaj</Link
          >
          <Link to="/auth/logout" class="btn btn-outline-success"
            >Wyloguj się</Link
          >
        {:else}
          <Link to="/manage" class="btn btn-outline-success">Zaloguj się</Link>
        {/if}
      </form>
    </div>
  </div>
</nav>

<style lang="scss">
  .logo {
    margin-top: 0.5rem;
    max-height: 40px;
  }
</style>
