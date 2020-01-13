<template>
  <b-container>
    <div>
      <p>
        1. First of all, you must create an account. Click
        <router-link to="/user/register">here</router-link>&nbsp;to open the registration page.
        <br />
        <strong>Note: The email will be used to login to the website, and the username to our game servers.</strong>
      </p>
    </div>
    <div>
      <p>
        2. Install the
        <a
          href="https://drive.google.com/open?id=1z8I_kdgkrNevwEGOPbSMhXlOEZGURVY8"
          target="_blank"
        >World of Warcraft WoTLK 3.3.5a</a> client (unless you already have one, which in that case, just proceed to step 3).
      </p>
    </div>
    <div>
      <p>
        3. Download our custom launcher. Click
        <a href="https://www.dropbox.com/s/vtesm5811m75u0x/titansleaguelauncher%20Setup.rar?dl=0">here</a>&nbsp;to download it.
        <br />
        This launcher is cross-platform and will work on any OS. Its open source made by <b>Vincent Vanclef</b>, and the source can be found <a href="https://github.com/VincentVanclef/TitansLeagueLauncher">here</a>&nbsp;.
        <br />
        It will handle all patch downloads for you, and ensure they are up-to-date whenever we change them.
      </p>
    </div>
    <div>
      <p>4. Open up the "World of Warcraft" directory. The default directory is "C:\Program Files\World of Warcraft". When you've found it, open up the directory called "data", then go into the directory called either enUS or enGB, depending on your client language.</p>
    </div>
    <div>
      <p>5. Open up the file called "realmlist.wtf" with a text editor such as Notepad. To do this, you must right click on the file and choose properties, then select notepad as the default software for files with the ".wtf" ending. You may also just start the text editor and drag the file into the edit window.</p>
    </div>
    <div>
      <p>6. Erase all text and change it to:</p>
    </div>
    <div>
      <p>
        set realmlist
        <strong>{{ realmlist }}</strong>
      </p>
    </div>
    <div>
      <p>You may now start playing! If you need any help, do not hesitate to create a support ticket.</p>
    </div>
  </b-container>
</template>

<script>
export default {
  props: ["realmlist"],
  name: "Connect",
  data() {
    return {};
  }
};
</script>
