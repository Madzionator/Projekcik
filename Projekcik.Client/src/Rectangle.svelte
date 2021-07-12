<script>
  export let content;
</script>

<div class="rectangle">
  <p class="rectangle__text">{content}</p>
</div>

<style>
  .rectangle {
    border: 2px solid black;
    height: 100px;
    margin: 5px;
    line-height: 100px;
    box-sizing: content-box;
    text-align: center;
  }

  .rectangle__text {
    animation: rotation 2s infinite linear;
  }

  @keyframes rotation {
    from {
      transform: rotate(0deg);
    }
    to {
      transform: rotate(359deg);
    }
  }
</style>
