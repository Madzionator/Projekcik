<script>
  import { Route } from "svelte-navigator";
  import AuthService from "../Services/AuthService";
  import { toast } from "@zerodevx/svelte-toast";
  import { navigate } from "svelte-navigator";

  if (!AuthService.isLogged()) {
    toast.push("Musisz się zalogować");
    navigate("/login", { replace: true });
  }

  export let routeParams;
</script>

<Route {...routeParams} />
