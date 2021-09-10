<script>
  import { navigate } from "svelte-navigator";
  import EditJobItem from "../../Components/EditJobItem.svelte";
  import JobService from "../../Services/JobService";
  import { toast } from "@zerodevx/svelte-toast";

  let errors;
</script>

<EditJobItem
  validationErrors={errors}
  onSave={(job) => {
    JobService.createJob(job)
      .then((response) => {
        toast.push("Udało się dodać ofertę 😻");
        navigate("/manage/jobs", { replace: true });
      })
      .catch((x) => {
        errors = x.response.data.errors;
        console.log(errors);
        toast.push("Nie udało się dodać oferty 😿");
      });
  }}
/>
