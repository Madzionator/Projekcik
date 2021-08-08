<script>
  import TodoItem from "../Components/TodoItem.svelte";
  import TimePicker from "svelte-time-picker";
  import Datepicker from "svelte-calendar";

  export let onSave;
  export let title = "";
  export let termin = new Date();

  function saveTodo() {
    if (onSave) onSave({ title, termin });
  }

  function calculateTime() {
    termin.setHours(selectedTime.getHours());
    termin.setMinutes(selectedTime.getMinutes());
    termin.setDate(selectedDate.getDate());
    termin.setMonth(selectedDate.getMonth());
    termin.setFullYear(selectedDate.getFullYear());
    termin = termin; // dont remove this line pls
  }

  let selectedDate = new Date(termin);
  let selectedTime = new Date(termin);
</script>

<div class="container">
  <div class="input">
    <p>Podaj tytuł, date i godzinę zadania:</p>
    <input bind:value={title} type="text" />

    <Datepicker
      bind:selected={selectedDate}
      format={(s) => {
        calculateTime();
      }}
    >
      <button class="custom-button">
        {selectedDate}
      </button>
    </Datepicker>

    <TimePicker date={selectedTime} on:change={calculateTime} />
  </div>

  <TodoItem {title} {termin} />

  {#if onSave}
    <button class="zapisz" on:click={saveTodo} disabled={title.length == 0}>
      zapisz zadanie
    </button>
  {/if}
</div>

<style>
  .zapisz {
    border: 1px solid rgb(65, 65, 65);
    height: 50px;
    width: 150px;
    border-radius: 20px;
    margin: 8px;
    font-weight: bold;
  }
</style>
