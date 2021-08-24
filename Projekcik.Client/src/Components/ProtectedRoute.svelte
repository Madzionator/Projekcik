<script>
  import AccessDeniedPage from "./../Pages/Auth/AccessDeniedPage.svelte";
  import { Route } from "svelte-navigator";
  import { token } from "../stores";

  $: isAuthenticated = $token;

  export let routeParams;
</script>

{#if isAuthenticated}
  <Route {...routeParams} />
{:else}
  <Route {...{ ...routeParams, component: AccessDeniedPage }} />
{/if}
