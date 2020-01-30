mergeInto(LibraryManager.library, {
  Exit: function(str) {
    console.log(str)
    ReactUnityWebGL.exit(Pointer_stringify(str));
  }
});