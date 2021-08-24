<script>
  import { toast } from "@zerodevx/svelte-toast";
  import qs from "query-string";
  import { navigate } from "svelte-navigator";

  const queryparams = qs.parse(location.search);
  queryparams["href"] = window.location.href;
  const queryParams2 = qs.stringify(queryparams);

  const loginUrl = "/login";
  const redirectUrl = `${loginUrl}?${queryParams2}`;
  navigate(redirectUrl, { replace: true });
  toast.push("Wymagane logowanie");
</script>
