<template>
  <b-container>
    <b-row>
      <b-col>
        <div>
          <p>
            1. First of all, you must create an account. Click
            <router-link to="/user/register">here</router-link>&nbsp;to open the
            registration page.
            <br />
            <strong
              >Note: The email will be used to login to the website, and the
              username to our game servers.</strong
            >
          </p>
        </div>
        <div>
          <p>
            2. Install the
            <a
              href="https://drive.google.com/open?id=1z8I_kdgkrNevwEGOPbSMhXlOEZGURVY8"
              target="_blank"
              >World of Warcraft WoTLK 3.3.5a</a
            >
            client (unless you already have one, which in that case, just
            proceed to step 3).
          </p>
        </div>
        <div>
          <p>
            3. Download our custom launcher. Click
            <a
              href="https://titans-league.org/static/downloads/TitansLeagueLauncherSetup.7z"
              target="_blank"
              >HERE</a
            >&nbsp;to download it.
            <img
              src="https://i.imgur.com/eLBOslu.png"
              style="width: 100%; max-height: 480px; margin-bottom: 15px; margin-top: 15px;"
            />

            <br />
            This launcher is cross-platform but for now will only support
            windows, due to the fact that it has to be built on macOS (Apple
            Limitations meh). Its open source made by <b>Vincent Vanclef</b>,
            and the source can be found
            <a href="https://github.com/VincentVanclef/TitansLeagueLauncher"
              >here</a
            >&nbsp;.
            <br />
            It will handle all patch downloads for you, and ensure they are
            up-to-date whenever we change them.
            <br />
            <b
              ><i
                >If you are on MAC you just need to dl this patch:
                <a
                  href="https://titans-league.org/static/downloads/Patch-V.mpq"
                  target="_blank"
                  >HERE</a
                >&nbsp;.</i
              ></b
            >
          </p>
        </div>
        <div>
          <p>
            4. After installing the launcher, just select your wow folder using
            it and then it will do the rest.
            <img
              src="https://i.imgur.com/ucLAvea.png"
              style="width: 100%; max-height: 480px; margin-bottom: 15px; margin-top: 15px;"
            />
          </p>
        </div>
        <div>
          <p>
            5. Press "start game". If there are any patches you need or that
            needs to be updated, the launcher will do that for you.
          </p>

          <img
            src="https://i.imgur.com/iwbwZaS.gif"
            style="width: 100%; max-height: 480px; margin-bottom: 15px; margin-top: 15px;"
          />
        </div>
        <div class="pb-4">
          <p>
            You may now start playing! If you need any help, do not hesitate to
            create a support ticket.
          </p>
        </div>
      </b-col>
    </b-row>
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
