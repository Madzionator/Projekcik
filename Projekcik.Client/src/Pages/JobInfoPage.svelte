<script>
  import marked from "marked";
  import { toast } from "@zerodevx/svelte-toast";

  import { onMount } from "svelte";
  import { navigate } from "svelte-navigator";
  import JobService from "../Services/JobService";

  export let id;
  let job;
  let keywords = ["C#", ".NET", "C++", "js"]; // temporary

  onMount(async () => {
    JobService.getJob(id)
      .then((response) => {
        job = response;
      })
      .catch((response) => {
        toast.push("oferta nie istnieje");
        navigate("/", { replace: true });
      });
  });
</script>

{#if job}
  <div class="container prostokat p-3 p-lg-5 mx-auto my-5">
    <h7 class="clue">Oferta pracy</h7>
    <h4>{job.title} <span class="company">{job.companyName}</span></h4>

    <div class="row">
      <div class="col-6">
        <p class="clue">Lokalizacja</p>
      </div>
      <div class="col-6">
        <p class="clue">Wynagrodzenie</p>
      </div>
    </div>
    <div class="row">
      <div class="col-6">
        {job.locations?.map((loc) => loc.name).join(", ") || "--"}
      </div>
      <div class="col-6">
        {job.minimumSalary ?? ""} - {job.maximumSalary ?? ""} PLN
      </div>
    </div>
    <div class="mt-2">
      {#each keywords as keyword}
        <span class="badge bg-secondary keyword">{keyword}</span>
      {/each}
    </div>
    <p class="clue">Opis</p>
    <div class="preview">{@html marked(job.description)}</div>
  </div>
{/if}

<style lang="scss">
  .prostokat {
    background-color: white;
    border: 1px solid black;
    border-radius: 5px;
    border-bottom-width: 2px;
    box-shadow: 3px 3px 10px rgba(0, 0, 0, 0.2);
  }
  .clue {
    color: grey;
    margin: 0.75rem 0 0 0;
  }
  .company {
    color: grey;
    font-size: large;
    font-weight: 400;
  }
  .keyword {
    margin: 3px;
    &:first-child {
      margin-left: 0;
    }
  }
</style>
