<script>
  import { Link } from "svelte-navigator";
</script>

<div class="p-3 p-lg-5 mx-auto my-5" style="text-align:center">
  <h4>Dziękujemy za aplikację.</h4>
  <h5>Skontaktujemy się.</h5>

  <div class="mt-4">
    <Link to="/">
      <button class="btn btn-success navigate">
        Powrót do strony głównej
      </button>
    </Link>
  </div>
</div>

<style lang="scss">
  .navigate {
    @import "src/global.scss";
    width: auto;
    background-color: rgba($green1, 0.8);
    color: black;
    &:hover,
    &:focus {
      background-color: $green2;
      color: black;
    }
  }
</style>
