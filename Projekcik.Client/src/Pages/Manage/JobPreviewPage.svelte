<script>
  import JobPreview from "../../Components/JobPreview.svelte";
  export let id;
  console.log(id);
</script>

<JobPreview {id} canApply={false} />
