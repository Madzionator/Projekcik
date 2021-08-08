<script>
  export let title;
  export let termin;
  export let onDeleteTodo;
  export let onEditTodo;

  let start = new Date();
  let diff = (termin - start) / (1000 * 60 * 60 * 24);
  let b_color;

  if (diff < 0) b_color = "lightgrey";
  else if (diff <= 1) b_color = "darkorange";
  else if (diff <= 7) b_color = "gold";
  else b_color = "white";
</script>

<div class="card todo_element" style="background-color: {b_color}">
  <div class="card-body">
    <h5 class="card-title todo_title">{title}</h5>
    {#if termin}
      <h6 class="card-subtitle mb-2 text-muted todo_date">
        {termin.toLocaleDateString()} o {termin.toLocaleTimeString()}
      </h6>
    {/if}
    {#if onDeleteTodo}
      <button
        type="button"
        class="btn btn-outline-danger todo_delete_button"
        on:click={() => onDeleteTodo && onDeleteTodo()}
        data-bs-toggle="tooltip"
        data-bs-placement="top"
        title="Usuń"><span class="fa fa-times" /></button
      >
    {/if}
    {#if onEditTodo}
      <button
        type="button"
        class="btn btn-outline-success todo_edit_button"
        on:click={() => onEditTodo && onEditTodo()}
        data-bs-toggle="tooltip"
        data-bs-placement="top"
        title="Edytuj"><span class="fas fa-pen" /></button
      >
    {/if}
  </div>
</div>

<style>
  .todo_element {
    max-width: 300px;
    margin: 5px;
    border-bottom: 2px solid gray;
  }
  .todo_title {
  }
  .todo_date {
  }
  .todo_delete_button {
  }
</style>
