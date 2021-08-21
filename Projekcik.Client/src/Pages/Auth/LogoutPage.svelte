<script>
  import { toast } from "@zerodevx/svelte-toast";

  import { onMount } from "svelte";

  import { navigate } from "svelte-navigator";
  import AuthService from "../../Services/AuthService";

  onMount(() => {
    AuthService.logout();
    navigate("/", { replace: true });
    toast.push("Wylogowano");
  });
</script>
