<script>
  import { navigate } from "svelte-navigator";
  import EditJobItem from "../../Components/EditJobItem.svelte";
  import JobService from "../../Services/JobService";
  import { toast } from "@zerodevx/svelte-toast";
  import { onMount } from "svelte";

  let errors;

  export let id;
  let job;

  onMount(async () => {
    JobService.getJob(id)
      .then((response) => {
        job = response;
      })
      .catch((response) => {
        toast.push("błąd");
        navigate("/manage/jobs", { replace: true });
      });
  });
</script>

{#if job}
  <EditJobItem
    {...job}
    validationErrors={errors}
    isEdit={true}
    onSave={(jb) => {
      JobService.editJob(job.id, jb)
        .then((response) => {
          toast.push("Udało się edytować ofertę 😻");
          navigate("/manage/jobs", { replace: true });
        })
        .catch((x) => {
          errors = x.response.data.errors;
          toast.push("Nie udało się edytować oferty 😿");
        });
    }}
  />
{/if}
